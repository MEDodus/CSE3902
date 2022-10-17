using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomLockedDoor : BottomBorder
    {
        public BottomLockedDoor() : base(BorderSpriteFactory.BottomLockedDoorSprite())
        {

        }
    }
}
