using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftDoor : LeftBorder
    {
        public LeftDoor() : base(BorderSpriteFactory.LeftDoorSprite())
        {

        }
    }
}
