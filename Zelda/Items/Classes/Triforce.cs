using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Triforce : IItem
    {
        public Triforce(Vector2 position) : base(ItemSpriteFactory.TriforceSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Triforce() : base(ItemSpriteFactory.TriforceSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
