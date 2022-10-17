using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class LeftLockedDoor : LeftBorder
    {
        public LeftLockedDoor() : base(BorderSpriteFactory.LeftLockedDoorSprite())
        {

        }
    }
}
