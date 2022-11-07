using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bow : IItem
    {
        public Bow(Vector2 position) : base(ItemSpriteFactory.BowSprite(), position, INFINITE)
        {

        }
    }
}
