using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class PushableBlock : Block
    {
        public bool Pushed { get { return animationComplete; } }

        private readonly double PUSH_DURATION = 0.6;

        private bool pushed = false;
        private bool animationComplete = false;
        private double pushTimer;
        private Vector2 startPosition;
        private Vector2 goalPosition;

        public PushableBlock(Vector2 position) : base(BlockSpriteFactory.PushableBlockSprite(), position, true, false)
        {

        }

        public void Push(Vector2 direction)
        {
            if (!pushed)
            {
                pushed = true;
                pushTimer = PUSH_DURATION;
                startPosition = position;
                goalPosition = position + new Vector2(Settings.BLOCK_SIZE * direction.X, Settings.BLOCK_SIZE * direction.Y);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (pushTimer > 0)
            {
                pushTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                position = startPosition + (goalPosition - startPosition) * (float)((PUSH_DURATION - pushTimer) / PUSH_DURATION);
                animationComplete = pushTimer <= 0;
            }
        }
    }
}
