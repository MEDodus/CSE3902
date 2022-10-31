using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftLockedDoor : LeftBorder
    {
        public LeftLockedDoor(Room room) : base(room, BorderSpriteFactory.LeftLockedDoorSprite(), true)
        {

        }
    }
}
