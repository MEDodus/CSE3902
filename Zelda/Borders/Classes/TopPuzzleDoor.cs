using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopPuzzleDoor : TopBorder
    {
        public TopPuzzleDoor(Room room) : base(room, BorderSpriteFactory.TopPuzzleDoorSprite(), true, false)
        {

        }
    }
}
