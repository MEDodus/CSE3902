using Microsoft.Xna.Framework;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class RightBorder : Border
    {
        public RightBorder(Room room, ISprite sprite, bool locked, bool isWall) : base(room, sprite, locked, isWall,
            new Vector2(Settings.ROOM_WIDTH * Settings.BLOCK_SIZE + Settings.BORDER_SIZE, Settings.BORDER_SIZE),
            new Vector2(Settings.BORDER_SIZE, Settings.ROOM_HEIGHT * Settings.BLOCK_SIZE))
        {

        }
    }
}
