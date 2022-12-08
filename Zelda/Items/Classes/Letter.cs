using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Letter : Item
    {
        public Letter(Vector2 position) : base(ItemSpriteFactory.LetterSprite(), position, ONE, null)
        {

        }
    }
}
