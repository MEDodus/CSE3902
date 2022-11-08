using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    internal class Heart
    {
        protected ISprite heart;
        protected Vector2 destination;
        public Heart()
        {
            this.heart = HUDSpriteFactory.FullHeart();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            heart.Draw(spriteBatch, destination);
        }
        public void SetDestination(int heartNum)
        {
            //this.destination = new Rectangle(HUDUtilities.HEALTH_DISPLAY_X + HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH * heartNum, HUDUtilities.HEALTH_DISPLAY_Y, HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_DISPLAY_ROW_HEIGHT);
            this.destination = new Vector2(HUDUtilities.HEALTH_DISPLAY_X + (HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH + HUDUtilities.HEART_OFFSET) * heartNum, HUDUtilities.HEALTH_DISPLAY_Y);
        }
        public void FullHeart()
        {
            this.heart = HUDSpriteFactory.FullHeart();
        }
        public void HalfHeart()
        {
            this.heart = HUDSpriteFactory.HalfHeart();
        }
        public void EmptyHeart()
        {
            this.heart = HUDSpriteFactory.EmptyHeart();
        }
        public void InvisibleHeart()
        {
            this.heart = HUDSpriteFactory.InvisibleHeart();
        }
    }
}
