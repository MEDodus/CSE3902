using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Zelda.Commands;
using Zelda.Commands.Classes;
using Zelda.GameStates.Classes;
using Zelda.Items.Classes;

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
        private static Stack<Keys> pressedLinkMovementKeys = new Stack <Keys>();
        private static Stack<Keys> pressedCompanionMovementKeys = new Stack<Keys>();

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
            pressedLinkMovementKeys.Push(Keys.D0);
            pressedCompanionMovementKeys.Push(Keys.D0);
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
            UpdateLinkKeys(pressedKeys);
        }

        private static void UpdateLinkKeys(Keys[] pressedKeys)
        {
            foreach (Keys pressedKey in pressedKeys)
            {
                if (linkMovementKeys.Contains(pressedKey) && !pressedLinkMovementKeys.Contains(pressedKey))
                {
                    pressedLinkMovementKeys.Push(pressedKey);
                }
                if (compMovementKeys.Contains(pressedKey) && !pressedCompanionMovementKeys.Contains(pressedKey))
                {
                    pressedCompanionMovementKeys.Push(pressedKey);
                }
            }
            while (!pressedLinkMovementKeys.Peek().Equals(Keys.D0) && !pressedKeys.Contains(pressedLinkMovementKeys.Peek()))
            {
                pressedLinkMovementKeys.Pop();
            }
            while (!pressedCompanionMovementKeys.Peek().Equals(Keys.D0) && !pressedKeys.Contains(pressedCompanionMovementKeys.Peek()))
            {
                pressedCompanionMovementKeys.Pop();
            }
        }

        public static bool PlayerMovingUpKey(int number)
        {
            if (number == 1)
            {
                return Keys.W.Equals(pressedLinkMovementKeys.Peek());
            }
            else
            {
                return Keys.Up.Equals(pressedCompanionMovementKeys.Peek());
            }
        }

        public static bool PlayerMovingDownKey(int number)
        {
            if (number == 1)
            {
                return Keys.S.Equals(pressedLinkMovementKeys.Peek());
            }
            else
            {
                return Keys.Down.Equals(pressedCompanionMovementKeys.Peek());
            }
        }

        public static bool PlayerMovingLeftKey(int number)
        {
            if (number == 1)
            {
                return Keys.A.Equals(pressedLinkMovementKeys.Peek());
            }
            else
            {
                return Keys.Left.Equals(pressedCompanionMovementKeys.Peek());
            }
        }

        public static bool PlayerMovingRightKey(int number)
        {
            if (number == 1)
            {
                return Keys.D.Equals(pressedLinkMovementKeys.Peek());
            }
            else
            {
                return Keys.Right.Equals(pressedCompanionMovementKeys.Peek());
            }
        }
    }
}