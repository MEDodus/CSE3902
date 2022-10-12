using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Arrow : INPC
    {
        public Arrow(Vector2 position) : base(ItemSpriteFactory.ArrowSprite(), position)
        {

        }
    }
}
