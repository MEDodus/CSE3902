using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Map : IItem
    {
        public Map(Vector2 position) : base(ItemSpriteFactory.MapSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Map() : base(ItemSpriteFactory.MapSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
