using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.Sprites;
using Zelda.Link;

/*
 * CSE 3902 Legend of Zelda
 * Autumn 2022 - Matt Boggus
 * 
 * Team Members:
 * Michael Dodus
 * Prithviraj Patel
 * Jacob Pohlabel
 * Alex Reed
 * Nichola Younoszai
 * Jiayuan Zhang
 */
namespace Zelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Tiles tiles;
        private Items items;
        private ILink link;
        private IController keyboard;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            keyboard = new KeyboardController();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Texture loading
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureStorage.LoadContent(Content);
            tiles = new Tiles();
            items = new Items();
            link = new Link2();

            // Registering commands keyboard class should probably call InitCommands initialing class instead
            Command.Init(keyboard, this, items, tiles);
        }

        protected override void Update(GameTime gameTime)
        {
            items.Update();
            link.Update();
            keyboard.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            tiles.Draw(_spriteBatch);
            items.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}