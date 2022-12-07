using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Raft : IItem
    {
        public Raft(Vector2 position) : base(ItemSpriteFactory.RaftSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Raft() : base(ItemSpriteFactory.RaftSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
