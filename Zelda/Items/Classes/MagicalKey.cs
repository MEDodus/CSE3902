using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalKey : Item
    {
        public MagicalKey(Vector2 position) : base(ItemSpriteFactory.MagicalKeySprite(), position, ONE, null)
        {

        }
    }
}
