using Microsoft.Xna.Framework;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class TopBorder : IBorder
    {
        public TopBorder(Room room, ISprite sprite, bool locked) : base(room, sprite, locked,
            new Vector2(0, 0),
            new Vector2((2 * Settings.BORDER_SIZE) + (Settings.ROOM_WIDTH * Settings.BLOCK_SIZE), Settings.BORDER_SIZE))
        {

        }
    }
}
