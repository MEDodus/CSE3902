using Microsoft.Xna.Framework;

namespace Zelda.Commands
{
    public interface ICommand
    {
        public void Execute(GameTime gameTime);
    }
}
