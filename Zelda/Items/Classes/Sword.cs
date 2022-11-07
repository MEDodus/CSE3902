using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Sword : IItem
    {
        // Working in inventory systems as Sword and SwordBeam projectiles at the moment
        public Sword(Vector2 position) : base(ItemSpriteFactory.SwordSprite(), position, INFINITE)
        {

        }
    }
}
