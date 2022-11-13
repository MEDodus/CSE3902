using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopLockedDoor : TopBorder
    {
        public TopLockedDoor(Room room) : base(room, BorderSpriteFactory.TopLockedDoorSprite(), true, false)
        {

        }
    }
}
