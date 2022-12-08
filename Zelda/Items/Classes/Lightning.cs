using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Lightning : IItem
    {
        public Lightning(Vector2 position) : base(ItemSpriteFactory.LightningSprite(), position, 0, new LightningEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Lightning() : base(ItemSpriteFactory.LightningSprite(), new Vector2(), 0, new LightningEffect())
        {

        }
    }
}
