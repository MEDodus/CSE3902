using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopLockedDoor : TopBorder
    {
        public TopLockedDoor() : base(BorderSpriteFactory.TopLockedDoorSprite())
        {

        }
    }
}
