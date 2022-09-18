using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public static class TextureStorage
    {
        // Enum for all of the different spritesheets
        public enum SpriteSheet
        {
            // TODO: enemies, blocks, items, projectiles

            // Link
            Link, // example

            // Block
            Block, // example
        };

        // Dictionary containing the spritesheet filenames for each sprite
        private static readonly Dictionary<SpriteSheet, string> FileNames = new Dictionary<SpriteSheet, string>()
        {
            //{GameSprite.Link, "LINK SPRITESHEET FILE"},
            //{GameSprite.Block, "BLOCK SPRITESHEET FILE"},
        };

        // Dictionary containing all of the loaded Texture2Ds for each sprite (initialized in LoadContent)
        private static readonly Dictionary<SpriteSheet, Texture2D> Textures = new Dictionary<SpriteSheet, Texture2D>();

        // Loads and stores textures for all sprites
        public static void LoadContent(ContentManager content)
        {
            foreach (KeyValuePair<SpriteSheet, string> pair in FileNames)
            {
                Texture2D texture = content.Load<Texture2D>(pair.Value);
                Textures.Add(pair.Key, texture);
            }
        }

        // Returns the created Texture2D associated with a given spritesheet
        public static Texture2D GetTexture(SpriteSheet sheetName)
        {
            return Textures.GetValueOrDefault(sheetName);
        }
    }

}
