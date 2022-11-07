﻿using Microsoft.Xna.Framework;
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
using Zelda.Blocks;

namespace Zelda.Collision.Handlers
{
    internal class PlayerEnemyCollisionHandler : ICollision
    {
        public PlayerEnemyCollisionHandler()
        {

        }

        public void HandleCollision()
        {

        }

        public void HandleCollision(ILink link, INPC enemy, Game1 game, GameTime gameTime)
        {
            if(enemy.Damage > 0)
            {
                game.link.TakeDamage(game, enemy.Damage);
            }
        }




    }
}
