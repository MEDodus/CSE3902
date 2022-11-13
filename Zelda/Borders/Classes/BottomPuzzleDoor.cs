using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomPuzzleDoor : BottomBorder
    {
        public BottomPuzzleDoor(Room room) : base(room, BorderSpriteFactory.BottomPuzzleDoorSprite(), true, false)
        {

        }
    }
}
