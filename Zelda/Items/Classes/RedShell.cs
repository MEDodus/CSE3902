using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedShell : IItem
    {
        public RedShell(Vector2 position) : base(ItemSpriteFactory.RedShellSprite(), position, 0, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public RedShell() : base(ItemSpriteFactory.RedShellSprite(), new Vector2(), 0, null)
        {

        }
    }
}
