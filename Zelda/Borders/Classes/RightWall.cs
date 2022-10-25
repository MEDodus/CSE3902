using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightWall : RightBorder
    {
        public RightWall() : base(BorderSpriteFactory.RightWallSprite(), true)
        {

        }
    }
}
