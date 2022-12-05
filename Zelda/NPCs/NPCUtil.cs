using Microsoft.Xna.Framework;
using System;
using Zelda.Items;
using Zelda.NPCs.Classes;
using Zelda.Rooms;

namespace Zelda.NPCs
{
    public static class NPCUtil
    {
        public static void MoveRandomly(EnemySingleDirection enemy)
        {
            int rand = new Random().Next(1, 5);
            switch (rand)
            {
                case 1:
                    enemy.MoveRight();
                    break;
                case 2:
                    enemy.MoveLeft();
                    break;
                case 3:
                    enemy.MoveUp();
                    break;
                case 4:
                    enemy.MoveDown();
                    break;
            }
        }

        public static void DropRandomItem(Vector2 position)
        {
            int x = new Random().Next(10);
            IItem droppedItem = null;
            if (x == 3 || x == 4)
            {
                droppedItem = new Items.Classes.Rupy(position);
            }
            else if (x == 5 || x == 6)
            {
                droppedItem = new Items.Classes.Heart(position);
            }
            else if (x == 7)
            {
                droppedItem = new Items.Classes.Fairy(position);
            }
            else if (x == 8)
            {
                droppedItem = new Items.Classes.Bomb(position);
            }
            else if (x == 9)
            {
                droppedItem = new Items.Classes.FiveRupies(position);
            }
            if (droppedItem != null)
            {
                RoomBuilder.Instance.CurrentRoom.Items.Add(droppedItem);
            }
        }
    }
}
