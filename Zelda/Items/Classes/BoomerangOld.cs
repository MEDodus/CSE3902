using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BoomerangOld : INPC
    {
        public BoomerangOld(Vector2 position) : base(ItemSpriteFactory.BoomerangSprite(), position)
        {

        }
    }
}
