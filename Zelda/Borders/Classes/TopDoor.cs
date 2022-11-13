using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopDoor : TopBorder
    {
        public TopDoor(Room room) : base(room, BorderSpriteFactory.TopDoorSprite(), false, false)
        {

        }
    }
}
