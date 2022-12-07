using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalKey : IItem
    {
        public MagicalKey(Vector2 position) : base(ItemSpriteFactory.MagicalKeySprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public MagicalKey() : base(ItemSpriteFactory.MagicalKeySprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
