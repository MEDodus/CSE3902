using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomDoor : BottomBorder
    {
        public BottomDoor(Room room) : base(room, BorderSpriteFactory.BottomDoorSprite(), false, false)
        {

        }
    }
}
