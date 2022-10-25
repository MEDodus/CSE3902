using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.HUD
{
    internal class Heart
    {
        protected ISprite heart;
        public Heart()
        {
            this.heart = HUDSpriteFactory.FullHeart();
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
    }
}
