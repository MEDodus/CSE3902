using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalRod : INPC
    {
        public MagicalRod(Vector2 position) : base(ItemSpriteFactory.MagicalRodSprite(), position)
        {

        }
    }
}
