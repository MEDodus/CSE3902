using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class GreenShell : IItem
    {
        public GreenShell(Vector2 position) : base(ItemSpriteFactory.HeartSprite(), position, 0, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public GreenShell() : base(ItemSpriteFactory.GreenShellSprite(), new Vector2(), 0, null)
        {

        }
    }
}
