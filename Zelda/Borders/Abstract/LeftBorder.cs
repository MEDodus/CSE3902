using Microsoft.Xna.Framework;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class LeftBorder : Border
    {
        public LeftBorder(Room room, ISprite sprite, bool locked, bool isWall) : base(room, sprite, locked, isWall,
            new Vector2(0, Settings.BORDER_SIZE),
            new Vector2(Settings.BORDER_SIZE, Settings.ROOM_HEIGHT * Settings.BLOCK_SIZE))
        {

        }
    }
}
