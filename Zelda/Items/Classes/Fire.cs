using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Fire : IItem
    {
        public Fire(Vector2 position) : base(ItemSpriteFactory.FireSprite(), position)
        {

        }
    }
}

