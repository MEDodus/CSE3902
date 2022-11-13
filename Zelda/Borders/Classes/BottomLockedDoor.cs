using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomLockedDoor : BottomBorder
    {
        public BottomLockedDoor(Room room) : base(room, BorderSpriteFactory.BottomLockedDoorSprite(), true, false)
        {

        }
    }
}
