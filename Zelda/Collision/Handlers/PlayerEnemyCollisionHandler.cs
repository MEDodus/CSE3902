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
using Zelda.Blocks;
using Zelda.Rooms;
using System.IO;
using Zelda.Sound;
using Zelda.Items.Classes;

namespace Zelda.Collision.Handlers
{
    public class PlayerEnemyCollisionHandler : ICollision
    {
        protected Direction collisionDirection;
        public PlayerEnemyCollisionHandler()
        {

        }

        public void HandleCollision()
        {

        }

        public void HandleCollision(ILink link, INPC npc, Game1 game, GameTime gameTime)
        {
            if (link.ItemTimer.Item is Star && link.ItemTimer.Duration > 0 && NPCUtil.IsEnemy(npc))
            {
                NPCUtil.DamageEnemy(npc);
                return;
            }

            if(npc.Damage > 0)
            {
                GetCollisionDirection(link, npc);
                Vector2 direction;
                switch (collisionDirection.Side)
                {
                    case Sides.left:
                        direction = new Vector2(-3*Settings.LINK_SPEED, 0);
                        break;
                    case Sides.right:
                        direction = new Vector2(3*Settings.LINK_SPEED, 0);
                        break;
                    case Sides.up:
                        direction = new Vector2(0, -3*Settings.LINK_SPEED);
                        break;
                    default:
                        direction = new Vector2(0, 3*Settings.LINK_SPEED);
                        break;
                }
                if(link.PlayerNumber == 1)
                {
                    game.Link.TakeDamage(npc.Damage, direction);
                } else
                {
                    game.LinkCompanion.TakeDamage(npc.Damage, direction);
                }
            }
        }


        protected void GetCollisionDirection(ILink link, INPC enemy)
        {
            Rectangle collisionArea = Rectangle.Intersect(link.Sprite.Destination, enemy.Sprite.Destination);
            if (collisionArea.Height > collisionArea.Width)
            {
                LeftOrRightCollision(link, enemy);
            }
            else
            {
                UpOrDownCollision(link, enemy);
            }


        }

        protected void UpOrDownCollision(ILink link, INPC enemy)
        {
            if (link.Sprite.Destination.Y > enemy.Sprite.Destination.Y)
            {
                collisionDirection = new Direction("down");
            }
            else
            {
                collisionDirection = new Direction("up");
            }
        }
        protected void LeftOrRightCollision(ILink link, INPC enemy)
        {
            if (link.Sprite.Destination.X > enemy.Sprite.Destination.X)
            {
                collisionDirection = new Direction("right");
            }
            else
            {
                collisionDirection = new Direction("left");
            }
        }

    }
}
