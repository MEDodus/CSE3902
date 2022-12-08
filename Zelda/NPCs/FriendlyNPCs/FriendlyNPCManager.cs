using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.NPCs.Classes;
using Zelda.NPCs.EnemyMultiDirection;
using Zelda.Rooms;
using Zelda.Sprites.Classes;

namespace Zelda.NPCs.FriendlyNPCs
{
    public class FriendlyNPCManager
    {
        private static FriendlyNPCManager instance = new FriendlyNPCManager();
        public static FriendlyNPCManager Instance { get { return instance; } }
        public List<IFriendlyNPC> FriendlyNPCs { get { return friendlyNPCs; } set { friendlyNPCs = value; } }

        protected List<IFriendlyNPC> friendlyNPCs;
        public FriendlyNPCManager()
        {
            //friendlyNPCs = new List<IFriendlyNPC>();
        }

        public void Initialize()
        {
            friendlyNPCs = new List<IFriendlyNPC>();
        }

        public void Update(Game1 game, GameTime gameTime)
        {
            if (friendlyNPCs.Any())
            { 
                foreach (IFriendlyNPC npc in friendlyNPCs)
                {
                    npc.Update(game, gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IFriendlyNPC npc in friendlyNPCs)
            {
                npc.Draw(spriteBatch);
            }
        }
        /*private void CheckOldManDead(Game1 game)
        {
            foreach (INPC npc in RoomBuilder.Instance.CurrentRoom.NPCs)
            {
                if (npc is OldMan && ((OldMan)npc).State is OldManGhostState)
                {
                    friendlyNPCs.Add(npc);
                    ((OldMan)npc).Dead = true;  //set to true so OldMan reference in Roombuilder.rooms[5] is removed
                }
            }
        }*/
    }
}
