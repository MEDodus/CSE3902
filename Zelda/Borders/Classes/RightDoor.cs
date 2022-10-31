using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightDoor : RightBorder
    {
        public RightDoor(Room room) : base(room, BorderSpriteFactory.RightDoorSprite(), false)
        {

        }
    }
}
