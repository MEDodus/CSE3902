using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Fairy : Item
    {
        public Fairy(Vector2 position) : base(ItemSpriteFactory.FairySprite(), position, 0, new FairyEffect())
        {

        }
    }
}
