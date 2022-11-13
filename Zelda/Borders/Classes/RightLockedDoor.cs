using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightLockedDoor : RightBorder
    {
        public RightLockedDoor(Room room) : base(room, BorderSpriteFactory.RightLockedDoorSprite(), true, false)
        {

        }
    }
}
