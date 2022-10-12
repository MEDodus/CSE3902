using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalBoomerang : INPC
    {
        public MagicalBoomerang(Vector2 position) : base(ItemSpriteFactory.MagicalBoomerangSprite(), position)
        {

        }
    }
}
