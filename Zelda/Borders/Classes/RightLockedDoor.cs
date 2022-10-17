using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightLockedDoor : RightBorder
    {
        public RightLockedDoor() : base(BorderSpriteFactory.RightLockedDoorSprite())
        {

        }
    }
}
