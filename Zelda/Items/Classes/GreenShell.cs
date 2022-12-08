using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class GreenShell : Item
    {
        public GreenShell(Vector2 position) : base(ItemSpriteFactory.GreenShellSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public GreenShell() : base(ItemSpriteFactory.GreenShellSprite(), new Vector2(), 0, null)
        {

        }
    }
}
