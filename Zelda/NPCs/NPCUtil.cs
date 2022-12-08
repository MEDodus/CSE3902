using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.NPCs.Classes;
using Group = Zelda.NPCs.INPC.Group;
using Vector2 = Microsoft.Xna.Framework.Vector2;

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

        public static Item GetItem(Group enemyGroup, int itemRow, Vector2 position)
        {
            int spawnMarioKartItem = new Random().Next(1, 5); // (1/2) * (1/4) = 1/8 chance of enemy dropping mario kart item
            if (spawnMarioKartItem == 1 && enemyGroup == Group.X)
            {
                return GetMarioKartItem(position);
            } else if (IsRupy(enemyGroup, itemRow))
            {
                return new Rupy(position);
            } else if (IsFiveRupies(enemyGroup, itemRow))
            {
                return new FiveRupies(position);
            } else if (IsBomb(enemyGroup, itemRow))
            {
                return new Bomb(position);
            } else if (IsHeart(enemyGroup, itemRow))
            {
                return new Heart(position);
            } else if (IsFairy(enemyGroup, itemRow))
            {
                return new Fairy(position);
            } else if (IsClock(enemyGroup, itemRow))
            {
                return new Clock(position);
            }
            return null;
        }

        public static Item GetMarioKartItem(Vector2 position)
        {
            int marioKartItem = new Random().Next(1, 7); // 6 mario kart items total
            switch(marioKartItem)
            {
                case 1:
                    return new GreenShell(position);
                case 2:
                    return new RedShell(position);
                case 3:
                    return new Star(position);
                case 4:
                    return new Banana(position);
                case 5:
                    return new Mushroom(position);
                case 6:
                    return new Lightning(position);
                default:
                    return null;
            }
        }

        public static bool IsRupy(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 0:
                    return enemyGroup == Group.A || enemyGroup == Group.C;
                case 1:
                    return enemyGroup == Group.B;
                case 2:
                    return enemyGroup == Group.A || enemyGroup == Group.C || enemyGroup == Group.D;
                case 3:
                    return enemyGroup == Group.B;
                case 4:
                    return enemyGroup == Group.A;
                case 6:
                    return enemyGroup == Group.B || enemyGroup == Group.C;
                case 7:
                    return enemyGroup == Group.A || enemyGroup == Group.C;
                case 8:
                    return enemyGroup == Group.A || enemyGroup == Group.C || enemyGroup == Group.D;
                default:
                    return false;
            }
        }

        public static bool IsFiveRupies(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 3:
                    return enemyGroup == Group.C;
                case 9:
                    return enemyGroup == Group.C;
                default:
                    return false;
            }
        }
        public static bool IsClock(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 2:
                    return enemyGroup == Group.B;
                case 5:
                    return enemyGroup == Group.C;
                default:
                    return false;
            }
        }

        public static bool IsBomb(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 0:
                    return enemyGroup == Group.B;
                case 5:
                    return enemyGroup == Group.B;
                case 7:
                    return enemyGroup == Group.B;
                default:
                    return false;
            }
        }

        public static bool IsFairy(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 1:
                    return enemyGroup == Group.D;
                case 3:
                    return enemyGroup == Group.A;
                case 4:
                    return enemyGroup == Group.D;
                default:
                    return false;
            }
        }

        public static bool IsHeart(Group enemyGroup, int itemRow)
        {
            switch (itemRow)
            {
                case 0:
                    return enemyGroup == Group.D;
                case 1:
                    return enemyGroup == Group.A || enemyGroup == Group.C;
                case 3:
                    return enemyGroup == Group.D;
                case 4:
                    return enemyGroup == Group.B || enemyGroup == Group.C;
                case 5:
                    return enemyGroup == Group.A || enemyGroup == Group.D;
                case 6:
                    return enemyGroup == Group.A || enemyGroup == Group.D;
                case 7:
                    return enemyGroup == Group.D;
                case 8:
                    return enemyGroup == Group.B;
                case 9:
                    return enemyGroup == Group.A || enemyGroup == Group.B || enemyGroup == Group.D;
                default:
                    return false;
            }
        }

    }
}
