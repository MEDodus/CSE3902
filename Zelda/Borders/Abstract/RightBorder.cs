using Microsoft.Xna.Framework;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class RightBorder : IBorder
    {
        public RightBorder(Room room, ISprite sprite, bool locked) : base(room, sprite, locked,
            new Vector2(Settings.ROOM_WIDTH * Settings.BLOCK_SIZE, 0),
            new Vector2(Settings.BORDER_SIZE, Settings.ROOM_HEIGHT * Settings.BLOCK_SIZE))
        {

        }
    }
}
