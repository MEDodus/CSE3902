using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomWall : BottomBorder
    {
        public BottomWall(Room room) : base(room, BorderSpriteFactory.BottomWallSprite(), true, true)
        {

        }
    }
}
