using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalBoomerang : IItem
    {
        // Working in inventory system as MagicalBoomerang projectile at the moment
        public MagicalBoomerang(Vector2 position) : base(ItemSpriteFactory.MagicalBoomerangSprite(), position, INFINITE, null)
        {

        }
    }
}
