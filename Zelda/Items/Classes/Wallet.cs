using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Wallet : IItem
    {
        public Wallet(Vector2 position) : base(ItemSpriteFactory.RupySprite(), new Vector2(), 255, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Wallet() : base(ItemSpriteFactory.RupySprite(), new Vector2(), 255, null)
        {

        }
    }
}
