using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private static HashSet<Keys> movementKeys = new HashSet<Keys>();
        private static Keys mostRecentMoveKey;

        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            this.game = game;
            movementKeys.Add(Keys.W);
            movementKeys.Add(Keys.A);
            movementKeys.Add(Keys.S);
            movementKeys.Add(Keys.D);
            movementKeys.Add(Keys.Up);
            movementKeys.Add(Keys.Left);
            movementKeys.Add(Keys.Down);
            movementKeys.Add(Keys.Right);
            mostRecentMoveKey = Keys.Up;
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

        public static Keys mostRecentMovementKey(Keys key)
        {
            Keys[] oldPressedKeys = previousState.GetPressedKeys();
            Keys[] newPressedKeys = currentState.GetPressedKeys();
            if(currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
            {
                mostRecentMoveKey = key;
            }
            if (currentState.IsKeyUp(mostRecentMoveKey) && previousState.IsKeyDown(mostRecentMoveKey))
            {
                foreach(Keys pressedKey in newPressedKeys)
                {
                    if (movementKeys.Contains(pressedKey))
                    {
                        mostRecentMoveKey = pressedKey;
                    }
                }
            }
            return mostRecentMoveKey;
        }
    }
}
