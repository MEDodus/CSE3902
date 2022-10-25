using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Blocks;
using Zelda.Blocks.Classes;

namespace Zelda.Collision.Handlers
{
    internal class PlayerBlockCollisionHandler : ICollision
    {
        protected Direction collisionDirection;

        public PlayerBlockCollisionHandler()
        {

        }

        public void HandleCollision()
        {
            
        }

        public void HandleCollision(ILink link, IBlock block)
        {
            if (!block.CanCollide)
                return;

            GetCollisionDirection(link, block);
            Rectangle linkRectangle = link.Sprite.Destination;
            Rectangle blockRectangle = block.Sprite.Destination;
            Vector2 blockPosition = new Vector2(blockRectangle.X, blockRectangle.Y);
            float x = link.Position.X;
            float y = link.Position.Y;
            switch (collisionDirection.Side)
            {
                case Sides.left:
                    x = blockPosition.X - linkRectangle.Width;
                    break;
                case Sides.right:
                    x = blockPosition.X + blockRectangle.Width;
                    break;
                case Sides.up:
                    y = blockPosition.Y - linkRectangle.Height;
                    break;
                case Sides.down:
                    y = blockPosition.Y + blockRectangle.Height;
                    break;
                default:
                    break;
            }
            link.Position = new Vector2(x, y);
            if (block is PushableBlock)
            {
                PushableBlock pushable = (PushableBlock)block;
                pushable.Push(-collisionDirection.Vector);
            }
        }

        protected void GetCollisionDirection(ILink link, IBlock block)
        {
            Rectangle collisionArea = Rectangle.Intersect(link.Sprite.Destination, block.Sprite.Destination);
            if (collisionArea.Height > collisionArea.Width)
            {
                LeftOrRightCollision(link, block);
            }
            else
            {
                UpOrDownCollision(link, block);
            }


        }

        protected void UpOrDownCollision(ILink link, IBlock block)
        {
            if (link.Sprite.Destination.Y > block.Sprite.Destination.Y)
            {
                collisionDirection = new Direction("down");
            }
            else
            {
                collisionDirection = new Direction("up");
            }
        }
        protected void LeftOrRightCollision(ILink link, IBlock block)
        {
            if (link.Sprite.Destination.X > block.Sprite.Destination.X)
            {
                collisionDirection = new Direction("right");
            }
            else
            {
                collisionDirection = new Direction("left");
            }
        }
    }
}
