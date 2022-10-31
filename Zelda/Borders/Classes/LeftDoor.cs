using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftDoor : LeftBorder
    {
        public LeftDoor(Room room) : base(room, BorderSpriteFactory.LeftDoorSprite(), false)
        {

        }
    }
}
