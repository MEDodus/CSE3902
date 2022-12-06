using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Sword : IItem
    {
        public Sword(Vector2 position) : base(ItemSpriteFactory.SwordSprite(), position, INFINITE, new Zelda.ItemEffects.SwordEffect())
        {

        }
    }
}
