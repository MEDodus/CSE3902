using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class HeartContainer : IItem
    {
        public HeartContainer(Vector2 position) : base(ItemSpriteFactory.HeartContainerSprite(), position, 0, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public HeartContainer() : base(ItemSpriteFactory.HeartContainerSprite(), new Vector2(), 0, null)
        {

        }
    }
}
