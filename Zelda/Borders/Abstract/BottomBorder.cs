using Microsoft.Xna.Framework;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class BottomBorder : IBorder
    {
        public BottomBorder(ISprite sprite) : base(sprite,
            new Rectangle(
                Settings.ROOM_POSITION_X - Settings.BORDER_SIZE,
                Settings.ROOM_POSITION_Y + (7 * Settings.BLOCK_SIZE),
                (2 * Settings.BORDER_SIZE) + (12 * Settings.BLOCK_SIZE),
                Settings.BORDER_SIZE
            ))
        {

        }
    }
}
