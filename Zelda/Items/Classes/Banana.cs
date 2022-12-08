using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Banana : Item
    {
        public Banana(Vector2 position) : base(ItemSpriteFactory.BananaSprite(), position, 0, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Banana() : base(ItemSpriteFactory.BananaSprite(), new Vector2(), 0, null)
        {

        }
    }
}
