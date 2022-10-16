using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Commands;

namespace Zelda.Controllers
{
    public class MouseController : IController
    {
        HashSet<ICommand> leftClickCommands;
        HashSet<ICommand> rightClickCommands;

        public MouseController()
        {
            leftClickCommands = new HashSet<ICommand>();
            rightClickCommands = new HashSet<ICommand>();
        }

        public void RegisterLeftClickCommand(ICommand command)
        {
            {
                leftClickCommands.Add(command);
            }
        }

        public void RegisterRightClickCommand(ICommand command)
        {
            {
                rightClickCommands.Add(command);
            }
        }

        private void ExecuteCommands(GameTime gameTime, HashSet<ICommand> commands, ButtonState state)
        {
            if (state == ButtonState.Pressed)
            {
                foreach (ICommand command in commands)
                {
                    command.Execute(gameTime);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            ExecuteCommands(gameTime, leftClickCommands, state.LeftButton);
            ExecuteCommands(gameTime, rightClickCommands, state.RightButton);
        }
    }
}
