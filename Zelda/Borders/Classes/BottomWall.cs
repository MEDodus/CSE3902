using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomWall : BottomBorder
    {
        public BottomWall() : base(BorderSpriteFactory.BottomWallSprite(), true)
        {

        }
    }
}
