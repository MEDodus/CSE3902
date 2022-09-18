using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public static class TextureStorage
    {
        // Enum for all of the different sprites in the game
        public enum GameSprite
        {
            // TODO: enemies, blocks, items, projectiles

            // Link
            Link, // example

            // Block
            Block, // example
        };

        // Dictionary containing the spritesheet filenames for each sprite
        private static Dictionary<GameSprite, string> TextureIds = new Dictionary<GameSprite, string>()
        {
            //{GameSprite.Link, "LINK SPRITESHEET FILE"},
            //{GameSprite.Block, "BLOCK SPRITESHEET FILE"},
        };

        // Dictionary containing all of the loaded Texture2Ds for each sprite (initialized in LoadContent)
        private static Dictionary<GameSprite, Texture2D> Textures = new Dictionary<GameSprite, Texture2D>();

        // Loads and stores textures for all sprites
        public static void LoadContent(ContentManager content)
        {
            foreach (KeyValuePair<GameSprite, string> pair in TextureIds)
            {
                Texture2D texture = content.Load<Texture2D>(pair.Value);
                Textures.Add(pair.Key, texture);
            }
        }

        public static Texture2D GetTexture(GameSprite spriteKey)
        {
            return Textures.GetValueOrDefault(spriteKey);
        }
    }

}
