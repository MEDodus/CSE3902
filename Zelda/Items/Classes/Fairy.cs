using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Fairy : INPC
    {
        public Fairy(Vector2 position) : base(ItemSpriteFactory.FairySprite(), position)
        {

        }
    }
}
