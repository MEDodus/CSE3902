using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopWall : TopBorder
    {
        public TopWall() : base(BorderSpriteFactory.TopWallSprite())
        {

        }
    }
}
