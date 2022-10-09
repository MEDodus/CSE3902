using System;
using Zelda.NPCs.Classes;

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
    }
}
