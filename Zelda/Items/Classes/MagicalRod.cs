using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalRod : IItem
    {
        public MagicalRod(Vector2 position) : base(ItemSpriteFactory.MagicalRodSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public MagicalRod() : base(ItemSpriteFactory.MagicalRodSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
