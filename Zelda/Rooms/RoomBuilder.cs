using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Rooms.Classes;

namespace Zelda.Rooms
{
    public class RoomBuilder
    {
        private IRoom[] rooms = new IRoom[1];
        private int i = 0;

        public RoomBuilder()
        {
            rooms[0] = new EntranceRoom();
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
            i--;
            if (i < 0)
            {
                i = rooms.Length;
            }
        }
    }
}
