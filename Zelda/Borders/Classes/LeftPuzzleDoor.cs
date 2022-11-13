using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftPuzzleDoor : LeftBorder
    {
        public LeftPuzzleDoor(Room room) : base(room, BorderSpriteFactory.LeftPuzzleDoorSprite(), true, false)
        {

        }
    }
}
