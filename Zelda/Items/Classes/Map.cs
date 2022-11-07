using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Map : IItem
    {
        public Map(Vector2 position) : base(ItemSpriteFactory.MapSprite(), position, ONE)
        {

        }
    }
}
