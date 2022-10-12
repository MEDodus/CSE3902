using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Rupy : INPC
    {
        public Rupy(Vector2 position) : base(ItemSpriteFactory.RupySprite(), position)
        {

        }
    }
}
