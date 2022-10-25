using Microsoft.Xna.Framework;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class LeftBorder : IBorder
    {
        public LeftBorder(ISprite sprite, bool locked) : base(sprite,
            new Rectangle(
                Settings.ROOM_POSITION_X - Settings.BORDER_SIZE,
                Settings.ROOM_POSITION_Y,
                Settings.BORDER_SIZE,
                7 * Settings.BLOCK_SIZE
            ), locked)
        {

        }
    }
}
