using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Rooms.Classes;

namespace Zelda.Rooms
{
    public class RoomBuilder
    {
        private IRoom[] rooms = new IRoom[17];
        private int i;

        public IRoom CurrentRoom 
        { 
            get { return rooms[i]; } 
            set { rooms[i] = value; } 
        }

        public RoomBuilder()
        {
            i = 15;
            rooms[0] = new Room0();
            rooms[1] = new Room1();
            rooms[2] = new Room2();
            rooms[3] = new Room3();
            rooms[4] = new Room4();
            rooms[5] = new Room5();
            rooms[6] = new Room6();
            rooms[7] = new Room7();
            rooms[8] = new Room8();
            rooms[9] = new Room9();
            rooms[10] = new Room10();
            rooms[11] = new Room11();
            rooms[12] = new Room12();
            rooms[13] = new Room13();
            rooms[14] = new Room14();
            rooms[15] = new Room15();
            rooms[16] = new Room16();
        }

        public void Update(GameTime gameTime)
        {
            rooms[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rooms[i].Draw(spriteBatch);
        }

        public void NextRoom()
        {
            i = (i + 1) % rooms.Length;
        }

        public void PreviousRoom()
        {
            i = i > 0 ? i - 1 : rooms.Length - 1;
        }
    }
}
