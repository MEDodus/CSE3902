using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Items.Classes;
using Zelda.Rooms;

namespace Zelda.Collision.Handlers
{
    public class PlayerBlockCollisionHandler : ICollision
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
            Vector2 blockPosition = block.Position;
            float x = link.Position.X;
            float y = link.Position.Y;
            Room.Direction roomDirection;
            switch (collisionDirection.Side)
            {
                case Sides.left:
                    x = blockPosition.X - linkRectangle.Width;
                    roomDirection = Room.Direction.Right;
                    break;
                case Sides.right:
                    x = blockPosition.X + blockRectangle.Width;
                    roomDirection = Room.Direction.Left;
                    break;
                case Sides.up:
                    y = blockPosition.Y - linkRectangle.Height;
                    roomDirection = Room.Direction.Down;
                    break;
                default:
                    y = blockPosition.Y + blockRectangle.Height;
                    roomDirection = Room.Direction.Up;
                    break;
            }
            link.Position = new Vector2(x, y);
            if (block is PushableBlock)
            {
                PushableBlock pushable = (PushableBlock)block;
                pushable.Push(-collisionDirection.Vector);
            }
            else if (block is Door && block.CanCollide && link.Inventory.FindInSet(new Key(new Vector2())))
            {
                link.Inventory.RemoveItem(new Key(new Vector2()), 1);
                RoomBuilder.Instance.CurrentRoom.UnlockDoor(roomDirection, true);
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
