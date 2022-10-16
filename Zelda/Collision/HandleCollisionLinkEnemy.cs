using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.NPCs;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.NPCs.Classes;

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
