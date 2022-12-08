using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Link;
using Zelda.NPCs;
using Zelda.NPCs.Classes;
using Zelda.Rooms;

namespace Zelda.ItemEffects
{
    public class LightningEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }

        public bool UseEffect(IItem item, IInventory inventory, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            HashSet<INPC> npcs = RoomBuilder.Instance.CurrentRoom.NPCs;
            foreach (INPC npc in npcs) 
            {
                if (npc is EnemyMultiDirection)
                {
                    ((EnemyMultiDirection)npc).Die();
                } else if (npc is EnemySingleDirection)
                {
                    ((EnemySingleDirection)npc).Die();
                }
            }
            return true;
        }
    }
}
