using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Stepladder : IItem
    {
        public Stepladder(Vector2 position) : base(ItemSpriteFactory.StepladderSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Stepladder() : base(ItemSpriteFactory.StepladderSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
