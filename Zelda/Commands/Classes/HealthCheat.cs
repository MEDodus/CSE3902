using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class HealthCheat : ICommand
    {
        private Game1 game;

        public HealthCheat(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.Link.Health.addMaxHealth(24);
            game.Link.Health.healthToFull();
        }
    }
}