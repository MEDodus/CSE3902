using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public static class TextureStorage
    {
        public enum SpriteSheet
        {
            // TODO: enemies, blocks, items, projectiles

            // Link
            Link, // example

            // Block
            Block, // example

            // Tile
            Tile, // being used
        };

        private static readonly Dictionary<SpriteSheet, string> FileNames = new Dictionary<SpriteSheet, string>()
        {
            //{GameSprite.Link, "LINK SPRITESHEET FILE"},
            //{GameSprite.Block, "BLOCK SPRITESHEET FILE"},
            {SpriteSheet.Tile, "TILE SPRITESHEET FILE"}
        };

        private static readonly Dictionary<SpriteSheet, Texture2D> Textures = new Dictionary<SpriteSheet, Texture2D>();

        public static void LoadContent(ContentManager content)
        {
            foreach (KeyValuePair<SpriteSheet, string> pair in FileNames)
            {
                Texture2D texture = content.Load<Texture2D>(pair.Value);
                Textures.Add(pair.Key, texture);
            }
        }

        public static Texture2D GetTexture(SpriteSheet sheetName)
        {
            return Textures.GetValueOrDefault(sheetName);
        }
    }

}
