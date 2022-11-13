using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class DungeonHUDMap : IHUDElement
    {
        protected ISprite map;
        protected Vector2 destination;
        public DungeonHUDMap()
        {
            map = HUDSpriteFactory.DungeonHUDMap();
            destination = new Vector2(HUDUtilities.MAP_X, HUDUtilities.MAP_Y);
        }

        public void Update(GameTime gameTime, ILink link)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, destination);
        }
    }
}
