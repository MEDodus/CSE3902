using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.NPCs;

namespace Zelda.Collision
{
    internal class HandleCollisionLinkEnemy
    {
        public HandleCollisionLinkEnemy(ILink link, INPC enemy, Game1 game, GameTime gameTime)
        {
            link.TakeDamage(game);
        }

    }
}
