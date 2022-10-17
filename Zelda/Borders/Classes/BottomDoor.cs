using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class BottomDoor : BottomBorder
    {
        public BottomDoor() : base(BorderSpriteFactory.BottomDoorSprite())
        {

        }
    }
}
