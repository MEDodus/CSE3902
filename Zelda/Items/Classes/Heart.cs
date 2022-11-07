using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Heart : IItem
    {
        public Heart(Vector2 position) : base(ItemSpriteFactory.HeartSprite(), position, 0)
        {

        }
    }
}
