using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Recorder : IItem
    {
        public Recorder(Vector2 position) : base(ItemSpriteFactory.RecorderSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Recorder() : base(ItemSpriteFactory.RecorderSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
