using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class WhiteSword : INPC
    {
        public WhiteSword(Vector2 position) : base(ItemSpriteFactory.WhiteSwordSprite(), position)
        {

        }
    }
}
