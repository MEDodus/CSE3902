using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Rupy : IItem
    {
        public Rupy(Vector2 position) : base(ItemSpriteFactory.RupySprite(), position, ONE, null)
        {

        }
    }
}
