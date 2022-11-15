using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Triforce : IItem
    {
        public Triforce(Vector2 position) : base(ItemSpriteFactory.TriforceSprite(), position, ONE, null)
        {

        }
    }
}
