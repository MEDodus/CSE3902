using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftWall : LeftBorder
    {
        public LeftWall() : base(BorderSpriteFactory.LeftWallSprite())
        {

        }
    }
}
