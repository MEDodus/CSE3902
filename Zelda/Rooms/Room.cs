using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.IO;

namespace Zelda.Rooms
{
    public class Room : IRoom
    {
        private StreamReader blockReader, itemReader, npcReader;
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private int roomNumber;
        private int rows;

        public Room()
        {
            blocks = new List<IBlock>();
            items = new List<IItem>();
            npcs = new List<INPC>();
            rows = 0;
            ReadFile();
        }

        public void ReadFile()
        {
            try
            {
                blockReader = new StreamReader("../../../RoomFiles/room_block" + roomNumber + ".csv");
            } catch
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in blocks)
            {
                // Change this to actual position
                block.Draw(spriteBatch);
            }

            foreach (IItem item in items)
            {
                // Change this to actual position
                item.Draw(spriteBatch);
            }

            foreach (INPC npc in npcs)
            {
                // Change this to actual position
                npc.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBlock block in blocks)
            {
                block.Update(gameTime);
            }

            foreach (IItem item in items)
            {
                item.Update(gameTime);
            }

            foreach (INPC npc in npcs)
            {
                npc.Update(gameTime);
            }
        }
    }
}
