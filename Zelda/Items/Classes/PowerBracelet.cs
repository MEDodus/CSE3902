using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class PowerBracelet : IItem
    {
        public PowerBracelet(Vector2 position) : base(ItemSpriteFactory.PowerBraceletSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public PowerBracelet() : base(ItemSpriteFactory.PowerBraceletSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
