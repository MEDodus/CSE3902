using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Boomerang : IItem
    {
        public Boomerang(Vector2 position) : base(ItemSpriteFactory.BoomerangSprite(), position, INFINITE, new Zelda.ItemEffects.BoomerangEffect())
        {

        }
    }
}
