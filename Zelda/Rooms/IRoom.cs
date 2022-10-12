﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Parsers;

namespace Zelda.Rooms
{
    public interface IRoom
    {
        public void ReadFile();
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}