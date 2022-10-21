using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Rooms
{
    public class RoomBuilder
    {
        private IRoom[] rooms = new IRoom[17];
        private int i;

        public IRoom CurrentRoom 
        { 
            get { return rooms[i]; } 
        }

        public RoomBuilder()
        {
            i = 15;
            for (int j = 0; j <= 16; j++)
            {
                rooms[i] = new DungeonRoom("Room" + j);
            }
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
