using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Key : IItem
    {
        public Key(Vector2 position) : base(ItemSpriteFactory.KeySprite(), position, INFINITE, new Zelda.ItemEffects.KeyEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Key() : base(ItemSpriteFactory.KeySprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.KeyEffect())
        {

        }
    }
}
