using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalKey : INPC
    {
        public MagicalKey(Vector2 position) : base(ItemSpriteFactory.MagicalKeySprite(), position)
        {

        }
    }
}
