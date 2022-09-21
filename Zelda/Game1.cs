using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using Zelda.Commands;
using Zelda.Controllers;

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
        private IController keyboard;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            keyboard = new KeyboardController();

            // TODO: add all keyboard keys as registered keys so no exeptions occur. as well as potentially a class to build all registered commands
            keyboard.RegisterCommand(Keys.D0, new Quit(this));
            keyboard.RegisterCommand(Keys.NumPad0, new Quit(this));

            // For player movement
            keyboard.RegisterCommand(Keys.W, new Up(this));
            keyboard.RegisterCommand(Keys.A, new Left(this));
            keyboard.RegisterCommand(Keys.S, new Down(this));
            keyboard.RegisterCommand(Keys.D, new Right(this));

            // For player attacks
            keyboard.RegisterCommand(Keys.Z, new Attack(this));
            keyboard.RegisterCommand(Keys.N, new Attack(this));

            // For usable items 
            keyboard.RegisterCommand(Keys.D1, new UseItem(this));
            keyboard.RegisterCommand(Keys.NumPad1, new UseItem(this));
            keyboard.RegisterCommand(Keys.D2, new UseItem(this));
            keyboard.RegisterCommand(Keys.NumPad2, new UseItem(this));
            keyboard.RegisterCommand(Keys.D3, new UseItem(this));
            keyboard.RegisterCommand(Keys.NumPad3, new UseItem(this));

            // For secondary items
            keyboard.RegisterCommand(Keys.X, new SecondaryItem(this));
            keyboard.RegisterCommand(Keys.M, new SecondaryItem(this));


            // The below keys only cycle between the previous or next sprite to be drawn for 
            // each object type. We could probably just have one command class instead of 6.

            // For blocks drawn to the screen
            keyboard.RegisterCommand(Keys.T, new CycleBlockPrevious(this));
            keyboard.RegisterCommand(Keys.Y, new CycleBlockNext(this));

            // For items drawn to the screen
            keyboard.RegisterCommand(Keys.U, new CycleItemPrevious(this));
            keyboard.RegisterCommand(Keys.I, new CycleItemNext(this));

            // For enemies drawn to the screen
            keyboard.RegisterCommand(Keys.O, new CycleEnemyPrevious(this));
            keyboard.RegisterCommand(Keys.P, new CycleEnemyNext(this));


            // For quiting and reset game state
            keyboard.RegisterCommand(Keys.Q, new Quit(this));
            keyboard.RegisterCommand(Keys.R, new Reset(this));


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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureStorage.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}