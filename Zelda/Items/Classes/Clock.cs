using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Clock : IItem
    {
        public Clock(Vector2 position) : base(ItemSpriteFactory.ClockSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Clock() : base(ItemSpriteFactory.ClockSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
