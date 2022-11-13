using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightPuzzleDoor : RightBorder
    {
        public RightPuzzleDoor(Room room) : base(room, BorderSpriteFactory.RightPuzzleDoorSprite(), true, false)
        {

        }
    }
}
