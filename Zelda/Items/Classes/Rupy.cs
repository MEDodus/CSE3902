using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Rupy : Item
    {
        // Can hold 100 5-rupies at the moment, refactor so rupy and five rupies are counted the same instead of via their classes
        public Rupy(Vector2 position) : base(ItemSpriteFactory.RupySprite(), position, 100, null)
        {

        }
    }
}
