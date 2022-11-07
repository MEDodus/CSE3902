using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Fairy : IItem
    {
        public Fairy(Vector2 position) : base(ItemSpriteFactory.FairySprite(), position, 0)
        {

        }
    }
}
