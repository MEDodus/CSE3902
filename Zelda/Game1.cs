using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.Sprites;

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
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Texture loading
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureStorage.LoadContent(Content);
            tiles = new Tiles();
            items = new Items();
            tiles.InitTiles();
            items.InitItems();

            // Registering commands
            InitCommands.Init(keyboard, this);
            InitCommands.InitTiles(keyboard, this, tiles);
            InitCommands.InitItems(keyboard, this, items);
        }

        protected override void Update(GameTime gameTime)
        {
            items.Update();
            keyboard.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            tiles.Draw(_spriteBatch);
            items.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}