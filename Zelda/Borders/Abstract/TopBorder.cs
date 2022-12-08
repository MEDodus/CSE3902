using Microsoft.Xna.Framework;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class TopBorder : Border
    {
        public TopBorder(Room room, ISprite sprite, bool locked, bool isWall) : base(room, sprite, locked, isWall,
            new Vector2(0, 0),
            new Vector2((2 * Settings.BORDER_SIZE) + (Settings.ROOM_WIDTH * Settings.BLOCK_SIZE), Settings.BORDER_SIZE))
        {

        }
    }
}
