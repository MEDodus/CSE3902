using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Commands;

namespace Zelda.Controllers
{
    public class KeyboardController : IController
    {
        Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            {
                controllerMappings.Add(key, command);
            }
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key)) controllerMappings[key].Execute(gameTime);
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
