using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Controllers;
using Zelda.Enemy;
using Zelda.Link;
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
        private ILink link;
        private IEnemy enemy;
        private IController keyboard;

        private int enemyCounter = 0;
        private IEnemy[] enemyClasses = new IEnemy[3];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            keyboard = new KeyboardController();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferredBackBufferWidth = 1024;
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
            enemy = new Jelly();//enemyClasses[enemyCounter];

            enemyClasses[0] = new Jelly();
            enemyClasses[1] = new Skeleton();
            enemyClasses[2] = new Goriya();

            // Registering commands keyboard class should probably call InitCommands initialing class instead
            Command.Init(keyboard, this, items, tiles, link, enemy);
        }

        protected override void Update(GameTime gameTime)
        {
            items.Update();
            link.Update();
            enemy.Update();
            keyboard.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            tiles.Draw(_spriteBatch);
            items.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);
            base.Draw(gameTime);
        }

        public void NextEnemy()
        {
            enemyCounter++;
            if (enemyCounter > 2)
            {
                enemyCounter = 0;
            }
            enemy = enemyClasses[enemyCounter];
        }
        public void PreviousEnemy()
        {
            enemyCounter--;
            if (enemyCounter < 0)
            {
                enemyCounter = 0;
            }
            enemy = enemyClasses[enemyCounter];
        }
    }
}