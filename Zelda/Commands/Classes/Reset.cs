using Microsoft.Xna.Framework;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Projectiles;

namespace Zelda.Commands.Classes
{
    public class Reset : ICommand
    {
        private Game1 game;

        public Reset(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.link.Reset();
            ProjectileStorage.Clear();
        }
    }
}
