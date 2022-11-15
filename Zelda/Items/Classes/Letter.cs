using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Letter : IItem
    {
        public Letter(Vector2 position) : base(ItemSpriteFactory.LetterSprite(), position, ONE, null)
        {

        }
    }
}
