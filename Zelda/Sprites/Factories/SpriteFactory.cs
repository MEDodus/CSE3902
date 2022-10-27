using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Zelda.Sprites.Factories
{
    // Contains content loading code shared by all sprite factories
    // Sprite factories are not static (as they must inherit this abstract class), but all of their methods are static
    public abstract class SpriteFactory
    {
        protected static ContentManager content;
        private static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public ContentManager Content { get { return content; } }

        public static void Initialize(ContentManager content)
        {
            SpriteFactory.content = content;
        }

        // Loads a texture on the first call, returns the same texture on any subsequent calls
        public static Texture2D GetTexture(string filename)
        {
            if (!Textures.ContainsKey(filename))
            {
                Textures.Add(filename, content.Load<Texture2D>("spritesheets\\" + filename));
            }
            return Textures[filename];
        }
    }

}
