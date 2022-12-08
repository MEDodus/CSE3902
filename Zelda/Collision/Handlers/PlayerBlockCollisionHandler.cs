using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Items.Classes;
using Zelda.Rooms;
using System.Collections.Generic;
using Zelda.Sound;

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

        public void HandleCollision(ILink link, Block block)
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
            else if (block is Door && block.CanCollide && link.Inventory.Contains(new Key(new Vector2())))
            {
                link.Inventory.GetItem(new Key(new Vector2())).UseItem(link.Inventory, null, new Vector2(), new Vector2());
                RoomBuilder.Instance.CurrentRoom.UnlockDoor(roomDirection, true);
            }
            else if (block is StairsTrigger)
            {
                SoundManager.Instance.PlayStairSound();
                RoomTransitions.EnterWhiteBrickDungeon();
            }
            else if (block is LadderTrigger)
            {
                RoomTransitions.LeaveWhiteBrickDungeon();
            }
        }

        protected void GetCollisionDirection(ILink link, Block block)
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

        protected void UpOrDownCollision(ILink link, Block block)
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
        protected void LeftOrRightCollision(ILink link, Block block)
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
