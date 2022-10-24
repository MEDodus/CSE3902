using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Collision
{
    public enum Sides { left, right, up, down, none }

    public class Direction
    {
        private Sides direction;
        private Vector2 vector;

        public Sides Side { get { return direction; } }
        public Vector2 Vector { get { return vector; } }

        public Direction(String direction)
        {
            switch (direction)
            {
                case "left":
                    this.direction = Sides.left;
                    this.vector = new Vector2(-1, 0);
                    break;
                case "right":
                    this.direction = Sides.right;
                    this.vector = new Vector2(1, 0);
                    break;
                case "up":
                    this.direction = Sides.up;
                    this.vector = new Vector2(0, -1);
                    break;
                case "down":
                    this.direction = Sides.down;
                    this.vector = new Vector2(0, 1);
                    break;
                default:
                    this.direction = Sides.none;
                    this.vector = new Vector2(0, 0);
                    break;
            }
        }


    }
}
