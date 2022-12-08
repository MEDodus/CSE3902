using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class WhiteSword : Item
    {
        public WhiteSword(Vector2 position) : base(ItemSpriteFactory.WhiteSwordSprite(), position, ONE, null)
        {

        }
    }
}
