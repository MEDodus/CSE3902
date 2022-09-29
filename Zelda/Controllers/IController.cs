using Microsoft.Xna.Framework.Input;
using Zelda.Commands;

namespace Zelda.Controllers
{
    public interface IController
    {
        public void RegisterCommand(Keys key, ICommand command);
        public void Update();
    }
}
