using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Raft : IItem
    {
        public Raft(Vector2 position) : base(ItemSpriteFactory.RaftSprite(), position)
        {

        }
    }
}
