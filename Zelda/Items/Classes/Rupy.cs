using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Rupy : IItem
    {
        // Can hold 100 5-rupies at the moment, refactor so rupy and five rupies are counted the same instead of via their classes
        public Rupy(Vector2 position) : base(ItemSpriteFactory.RupySprite(), position, 255, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Rupy() : base(ItemSpriteFactory.RupySprite(), new Vector2(), 255, null, 1)
        {

        }
    }
}
