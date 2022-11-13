using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Transactions;
using Zelda.Commands;
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

        public static bool HasBeenPressed(Keys key)
        {
            return currentState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }

        public void Update(GameTime gameTime)
        {
            // Must call static GetState() here to update previous and current keyboard state
            Keys[] pressedKeys = GetState().GetPressedKeys();
            bool paused = game.GameState is PausedGameState;
            if (!paused)
            {
                foreach (Keys key in pressedKeys)
                {

                    if (controllerMappings.ContainsKey(key) && !key.Equals(Keys.P))
                    {
                        controllerMappings[key].Execute(gameTime);
                    }
                    else if (HasBeenPressed(Keys.P) && key.Equals(Keys.P))
                    {
                        controllerMappings[Keys.P].Execute(gameTime);
                    }
                }
            } else if (paused)
            {
                // Allows quitting while game is paused
                if (HasBeenPressed(Keys.P) || HasBeenPressed(Keys.Q))
                {
                    controllerMappings[Keys.P].Execute(gameTime);
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
