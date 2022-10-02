﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Commands;

namespace Zelda.Controllers
{
    public class KeyboardController : IController
    {
        Dictionary<Keys, ICommand> controllerMappings;

        // No-arg constructor
        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        // Sets state of keyboard to whichever key was pressed.
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
    }
}
