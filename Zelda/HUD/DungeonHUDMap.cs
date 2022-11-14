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
        protected ISprite roomIndicator;
        protected Vector2 destination;
        protected Vector2 roomIndicatorPosition;
        public DungeonHUDMap()
        {
            map = HUDSpriteFactory.DungeonHUDMap();
            roomIndicator = HUDSpriteFactory.RoomIndicator();
            destination = new Vector2(HUDUtilities.MAP_X, HUDUtilities.MAP_Y);
            roomIndicatorPosition = new Vector2(HUDUtilities.MAP_X, HUDUtilities.MAP_Y);

        }

        public void Update(GameTime gameTime, ILink link)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, destination);
        }

        private Vector2 GetRoom()
        {
            return new Vector2(0, 0);
        }
    }
}
