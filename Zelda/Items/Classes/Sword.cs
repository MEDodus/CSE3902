using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Sword : IItem
    {
        // Working in inventory systems as Sword and SwordBeam projectiles at the moment
        public Sword(Vector2 position) : base(ItemSpriteFactory.SwordSprite(), position, INFINITE, new Zelda.ItemEffects.SwordEffect(), 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Sword() : base(ItemSpriteFactory.SwordSprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.SwordEffect(), 1)
        {

        }
    }
}
