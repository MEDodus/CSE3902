using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Recorder : IItem
    {
        public Recorder(Vector2 position) : base(ItemSpriteFactory.RecorderSprite(), position, ONE, null)
        {

        }
    }
}
