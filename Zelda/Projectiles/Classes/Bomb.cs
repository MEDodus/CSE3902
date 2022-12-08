using Microsoft.Xna.Framework;
using System;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Bomb : Projectile
    {
        public Bomb(Vector2 position) : base(ProjectileSpriteFactory.BombSprite(), position, new Vector2(), 0, 2, ProjectileBehavior.NeutralHarmless, false)
        {
            SoundManager.Instance.PlayBombDropSound();
        }

        private readonly int EXPLOSION_BUFFER_IN_PIXELS = 1 * Settings.BLOCK_SIZE;
        public override void OnDelete()
        {
            SoundManager.Instance.PlayBombBlowSound();
            Random rand = new Random();
            int numExplosions = rand.Next(4, 6);
            for (int i = 0; i < numExplosions; i++)
            {
                float x = position.X + rand.Next(-EXPLOSION_BUFFER_IN_PIXELS, EXPLOSION_BUFFER_IN_PIXELS);
                float y = position.Y + rand.Next(-EXPLOSION_BUFFER_IN_PIXELS, EXPLOSION_BUFFER_IN_PIXELS);
                Explosion explosion = new Explosion(new Vector2(x, y));
                ProjectileStorage.Add(explosion);
            }
        }
    }
}
