using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Sword : INPC
    {
        public Sword(Vector2 position) : base(ItemSpriteFactory.SwordSprite(), position)
        {

        }
    }
}
