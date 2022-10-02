using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalBoomerang : IItem
    {
        public MagicalBoomerang(Vector2 position) : base(ItemSpriteFactory.MagicalBoomerangSprite(), position)
        {

        }
    }
}
