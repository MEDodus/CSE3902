using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Map : INPC
    {
        public Map(Vector2 position) : base(ItemSpriteFactory.MapSprite(), position)
        {

        }
    }
}
