using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Transactions;
using Zelda.Commands;

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
            if (!game.Paused)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key) && !key.Equals(Keys.P)) controllerMappings[key].Execute(gameTime);
                    if (HasBeenPressed(Keys.P)) controllerMappings[Keys.P].Execute(gameTime);
                }
            } else if (game.Paused)
            {
                if (HasBeenPressed(Keys.P)) controllerMappings[Keys.P].Execute(gameTime);
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
