using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Arrow : IItem
    {
        public Arrow(Vector2 position) : base(ItemSpriteFactory.ArrowSprite(), position)
        {

        }
    }
}
