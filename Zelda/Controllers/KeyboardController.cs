using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Transactions;
using Zelda.Commands;
using Zelda.Commands.Classes;
using Zelda.GameStates.Classes;

namespace Zelda.Controllers
{
    public class KeyboardController : IController
    {
        Dictionary<Keys, ICommand> controllerMappings;
        private Game1 game;
        private static KeyboardState previousState;
        private static KeyboardState currentState;
        private static HashSet<Keys> linkMovementKeys = new HashSet<Keys>();
        private static HashSet<Keys> compMovementKeys = new HashSet<Keys>();
        private static Keys mostRecentMoveKeyLink, mostRecentMoveKeyComp;

        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            this.game = game;
            linkMovementKeys.Add(Keys.W);
            linkMovementKeys.Add(Keys.A);
            linkMovementKeys.Add(Keys.S);
            linkMovementKeys.Add(Keys.D);
            compMovementKeys.Add(Keys.Up);
            compMovementKeys.Add(Keys.Left);
            compMovementKeys.Add(Keys.Down);
            compMovementKeys.Add(Keys.Right);
            mostRecentMoveKeyLink = Keys.D0;
            mostRecentMoveKeyComp = Keys.D0;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            {
                controllerMappings.Add(key, command);
            }
        }

        public static KeyboardState GetState()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
            return currentState;
        }

        public static bool WasPressedForFirstTime(Keys key)
        {
            return currentState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }

        public void Update(GameTime gameTime)
        {
            // Must call static GetState() here to update previous and current keyboard state
            Keys[] pressedKeys = GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                // Skip over unmapped keys
                if (!controllerMappings.ContainsKey(key))
                {
                    continue;
                }
                // Skip over commands that can't be executed while the game is paused
                ICommand command = controllerMappings[key];
                bool allowExecutionWhilePaused = command is Pause || command is Quit || command is Left || command is Right || command is Up || command is Down;
                bool paused = game.GameState is PausedGameState;
                if (paused && !allowExecutionWhilePaused)
                {
                    continue;
                }
                // Execute command
                bool executeOnlyOnFirstPress = command is Pause || command is Mute || (paused && (command is Left || command is Right || command is Up || command is Down));
                if ((executeOnlyOnFirstPress && WasPressedForFirstTime(key)) || !executeOnlyOnFirstPress)
                {
                    command.Execute(gameTime);
                }
            }
        }

        public static Keys mostRecentLinkMovementKey(Keys key)
        {
            Keys[] oldPressedKeys = previousState.GetPressedKeys();
            Keys[] newPressedKeys = currentState.GetPressedKeys();
            Boolean anyMovementKeyPressed = false;
            foreach (Keys pressedKey in newPressedKeys)
            {
                if (linkMovementKeys.Contains(pressedKey)) { anyMovementKeyPressed = true; }
            }
            if (!anyMovementKeyPressed) { return Keys.D0; }
            if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
            {
                mostRecentMoveKeyLink = key;
            }
            if (currentState.IsKeyUp(mostRecentMoveKeyLink) && previousState.IsKeyDown(mostRecentMoveKeyLink))
            {
                foreach (Keys pressedKey in newPressedKeys)
                {
                    if (linkMovementKeys.Contains(pressedKey))
                    {
                        mostRecentMoveKeyLink = pressedKey;
                    }
                }
            }
            
            return mostRecentMoveKeyLink;
        }

        public static Keys mostRecentCompMovementKey(Keys key)
        {
            Keys[] oldPressedKeys = previousState.GetPressedKeys();
            Keys[] newPressedKeys = currentState.GetPressedKeys();
            Boolean anyMovementKeyPressed = false;
            foreach (Keys pressedKey in newPressedKeys)
            {
                if (compMovementKeys.Contains(pressedKey)) { anyMovementKeyPressed = true; }
            }
            if(!anyMovementKeyPressed) { return Keys.D0; }
            if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
            {
                mostRecentMoveKeyComp = key;
            }
            if (currentState.IsKeyUp(mostRecentMoveKeyComp) && previousState.IsKeyDown(mostRecentMoveKeyComp))
            {
                foreach (Keys pressedKey in newPressedKeys)
                {
                    if (compMovementKeys.Contains(pressedKey))
                    {
                        mostRecentMoveKeyComp = pressedKey;
                    }
                }
            }
            return mostRecentMoveKeyComp;
        }
    }
}
