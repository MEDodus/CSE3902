using Microsoft.Xna.Framework.Input;

namespace Zelda.Controllers
{
    public interface IController
    {
        public void RegisterCommand(Keys key, ICommand command);
        public void Update();
    }
}
