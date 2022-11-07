using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BluePotion : IItem
    {
        public BluePotion(Vector2 position) : base(ItemSpriteFactory.BluePotionSprite(), position, ONE)
        {

        }
    }
}
