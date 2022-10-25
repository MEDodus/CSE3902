using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class RightDoor : RightBorder
    {
        public RightDoor() : base(BorderSpriteFactory.RightDoorSprite(), false)
        {

        }
    }
}
