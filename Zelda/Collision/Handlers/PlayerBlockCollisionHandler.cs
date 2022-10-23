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
    internal class PlayerBlockCollisionHandler : ICollision
    {
        public PlayerBlockCollisionHandler()
        {

        }

        public void HandleCollision()
        {

        }

        public void HandleCollision(ILink link, IBlock block)
        {
            link.CancelMovement();
        }




    }
}
