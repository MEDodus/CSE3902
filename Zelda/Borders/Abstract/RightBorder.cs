using Microsoft.Xna.Framework;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class RightBorder : IBorder
    {
        public RightBorder(ISprite sprite) : base(sprite, 
            new Rectangle(
                Settings.ROOM_POSITION_X + (12 * Settings.BLOCK_SIZE), 
                Settings.ROOM_POSITION_Y,
                Settings.BORDER_SIZE,
                7 * Settings.BLOCK_SIZE
            ))
        {

        }
    }
}
