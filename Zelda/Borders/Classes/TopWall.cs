using Zelda.Borders.Classes.Abstract;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopWall : TopBorder
    {
        public TopWall(Room room) : base(room, BorderSpriteFactory.TopWallSprite(), true)
        {

        }
    }
}
