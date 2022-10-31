using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightWall : RightBorder
    {
        public RightWall(Room room) : base(room, BorderSpriteFactory.RightWallSprite(), true)
        {

        }
    }
}
