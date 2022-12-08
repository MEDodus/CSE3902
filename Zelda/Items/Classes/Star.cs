using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Star : Item
    {
        public Star(Vector2 position) : base(ItemSpriteFactory.StarSprite(), position, 0, new StarEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Star() : base(ItemSpriteFactory.StarSprite(), new Vector2(), 0, new StarEffect())
        {

        }
    }
}
