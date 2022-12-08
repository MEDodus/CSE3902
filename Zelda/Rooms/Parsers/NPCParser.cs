using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.NPCs;
using Zelda.NPCs.Classes;

namespace Zelda.Rooms.Parsers
{
    public class NPCParser : Parser
    {
        private HashSet<INPC> npcs;

        public NPCParser(Room room, HashSet<INPC> npcs) : base(room, room.Name + "\\npcs.csv")
        {
            this.npcs = npcs;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            INPC npc;
            Vector2 spawnPos = GetSpawnPosition(i, j, room);
            switch (identifier)
            {
                case "old_man":
                    npc = new OldMan(spawnPos);
                    break;
                case "bat":
                    npc = new Bat(spawnPos);
                    break;
                case "dragon":
                    npc = new Dragon(spawnPos);
                    break;
                case "gel":
                    npc = new Gel(spawnPos);
                    break;
                case "skeleton":
                    npc = new Skeleton(spawnPos);
                    break;
                case "spike_cross":
                    Vector2 moveDirection;
                    if (i == 0 && j == 0)
                    {
                        moveDirection = new Vector2(1, 0);
                    }
                    else if (i == 0 && j == Settings.ROOM_HEIGHT - 1)
                    {
                        moveDirection = new Vector2(0, -1);
                    }
                    else if (i == Settings.ROOM_WIDTH - 1 && j == 0)
                    {
                        moveDirection = new Vector2(0, 1);
                    }
                    else
                    {
                        moveDirection = new Vector2(-1, 0);
                    }
                    npc = new SpikeCross(spawnPos, moveDirection);
                    break;
                case "wallmaster":
                    npc = new Wallmaster(spawnPos);
                    break;
                case "zol":
                    npc = new Zol(spawnPos);
                    break;
                case "goriya":
                    npc = new Goriya(spawnPos);
                    break;
                case "dodongo":
                    npc = new Dodongo(spawnPos);
                    break;
                case "snake":
                    npc = new Snake(spawnPos);
                    break;
                default:
                    throw new Exception("NPC type not found: " + identifier);
            }

            npcs.Add(npc);
        }
    }
}
