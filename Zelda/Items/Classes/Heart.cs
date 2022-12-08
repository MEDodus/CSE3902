using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Heart : Item
    {
        public Heart(Vector2 position) : base(ItemSpriteFactory.HeartSprite(), position, 0, new HeartEffect())
        {

        }

        public Heart() : base(ItemSpriteFactory.HeartSprite(), new Vector2(), 0, new HeartEffect())
        {

        }
    }
}
