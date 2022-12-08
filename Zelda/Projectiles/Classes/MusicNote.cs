using Microsoft.Xna.Framework;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class MusicNote : Projectile
    {
        public MusicNote(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.MusicNoteSprite(), position, direction, 8, 3, ProjectileBehavior.Friendly)
        {
            SoundManager.Instance.PlayRecorderSound();
        }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
