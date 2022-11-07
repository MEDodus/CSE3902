using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class WhiteSword : IItem
    {
        public WhiteSword(Vector2 position) : base(ItemSpriteFactory.WhiteSwordSprite(), position, ONE)
        {

        }
    }
}
