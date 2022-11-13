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

        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            this.game = game;
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
                bool allowExecutionWhilePaused = command is Pause || command is Quit;
                if (game.GameState is PausedGameState && !allowExecutionWhilePaused)
                {
                    continue;
                }
                // Execute command
                bool executeOnlyOnFirstPress = command is Pause || command is Mute;
                if ((executeOnlyOnFirstPress && WasPressedForFirstTime(key)) || !executeOnlyOnFirstPress)
                {
                    command.Execute(gameTime);
                }
            }
        }

        public static bool AreMultipleKeysInSetPressed(HashSet<Keys> keys)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            int numPressed = 0;
            foreach (Keys key in pressedKeys)
            {
                if (keys.Contains(key)) numPressed++;
            }
            return numPressed > 1;
        }
    }
}
