using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftWall : LeftBorder
    {
        public LeftWall(Room room) : base(room, BorderSpriteFactory.LeftWallSprite(), true, true)
        {

        }
    }
}
