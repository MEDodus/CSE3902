using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.HUD
{
    public class BlackBorders
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawRectangle(spriteBatch, new Rectangle(0, 0, Settings.WINDOW_WIDTH, Settings.ROOM_WINDOW_Y)); // top
            DrawRectangle(spriteBatch, new Rectangle(0, Settings.ROOM_WINDOW_Y + Settings.ROOM_WINDOW_HEIGHT, 
                Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT - Settings.ROOM_WINDOW_Y - Settings.ROOM_WINDOW_HEIGHT)); // bottom
            DrawRectangle(spriteBatch, new Rectangle(0, 0, Settings.ROOM_WINDOW_X, Settings.WINDOW_HEIGHT)); // left
            DrawRectangle(spriteBatch, new Rectangle(Settings.ROOM_WINDOW_X + Settings.ROOM_WINDOW_WIDTH, 0, 
                Settings.WINDOW_WIDTH - Settings.ROOM_WINDOW_X - Settings.ROOM_WINDOW_WIDTH, Settings.WINDOW_HEIGHT)); // right
        }

        private static void DrawRectangle(SpriteBatch spriteBatch, Rectangle destination)
        {
            ISprite rectangle = HUDSpriteFactory.BlackBorder();
            rectangle.Draw(spriteBatch, destination);
        }
    }
}
