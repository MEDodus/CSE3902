using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Collision
{
    internal class Direction
    {
        enum Sides { left, right, up, down, none }
        private Sides direction;
        private Vector2 vector;

        public Direction(Vector2 vector)
        {
        }
        public Direction(String direction)
        {
            switch (direction)
            {
                case "left":
                    this.direction = Sides.left;
                    vector = new Vector2(-1, 0);
                    break;
                case "right":
                    this.direction = Sides.right;
                    vector = new Vector2(1, 0);
                    break;
                case "up":
                    this.direction = Sides.up;
                    vector = new Vector2(0, -1);
                    break;
                case "down":
                    this.direction = Sides.down;
                    vector = new Vector2(1, 0);
                    break;
                default:
                    this.direction = Sides.none;
                    vector = new Vector2(0, 0);
                    break;
            }
        }

        public Vector2 ToVector()
        {
            return this.vector;
        }

    }
}
