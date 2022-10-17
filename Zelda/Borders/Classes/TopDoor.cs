using Zelda.Borders.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Borders.Classes
{
    public class TopDoor : TopBorder
    {
        public TopDoor() : base(BorderSpriteFactory.TopDoorSprite())
        {

        }
    }
}
