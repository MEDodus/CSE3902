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
            int x = new Random().Next(15);
            IItem droppedItem = null;
            if (x < 4)
            {
                droppedItem = new Items.Classes.Rupy(position);
            }
            else if (x < 6)
            {
                droppedItem = new Items.Classes.Heart(position);
            }
            else if (x < 8)
            {
                droppedItem = new Items.Classes.Food(position);
            }
            else if (x < 10)
            {
                droppedItem = new Items.Classes.Bomb(position);
            }
            else if (x < 11)
            {
                droppedItem = new Items.Classes.Fairy(position);
            }
            else if (x < 12)
            {
                droppedItem = new Items.Classes.FiveRupies(position);
            }
            else if (x < 13)
            {
                droppedItem = new Items.Classes.BluePotion(position);
            }
            
            if (droppedItem != null)
            {
                RoomBuilder.Instance.CurrentRoom.Items.Add(droppedItem);
            }
        }
    }
}
