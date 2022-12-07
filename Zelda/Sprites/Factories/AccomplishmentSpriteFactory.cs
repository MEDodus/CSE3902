using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class AccomplishmentSpriteFactory : SpriteFactory
    {

        public static ISprite FirstKillSprite()
        {
            return new Sprite(GetTexture("Accomplish_FirstKill"));
        }

        public static ISprite DoorUnlockedSprite()
        {
            return new Sprite(GetTexture("Accomplish_DoorUnlocked"));
        }

        public static ISprite SecretWeaponSprite()
        {
            return new Sprite(GetTexture("Accomplish_SecretWeapon"));
        }

        public static ISprite DodongoScreamSprite()
        {
            return new Sprite(GetTexture("Accomplish_DodongoScream"));
        }
    }
}