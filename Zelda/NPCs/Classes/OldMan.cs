using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class OldMan : INPC
    {
        public OldMan(Vector2 position) : base(NPCSpriteFactory.OldManSprite(), position)
        {

        }
    }
}
