using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sprites.Factories;

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

        private List<IController> controllers;
        private RoomBuilder roomBuilder;
        public ILink link;
        private CommandBuilder commandBuilder;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferredBackBufferWidth = 1024;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // This must be done before creating any sprite objects (items, blocks, NPCs, etc.)
            SpriteFactory.Initialize(Content);

            // Create controllers
            controllers = new List<IController>();
            KeyboardController keyboard = new KeyboardController();
            MouseController mouse = new MouseController();
            controllers.Add(keyboard);
            controllers.Add(mouse);

            link = new Link2();
            roomBuilder = new RoomBuilder();
            commandBuilder = new CommandBuilder(keyboard, mouse, this, link, roomBuilder);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update(gameTime);
            }
            roomBuilder.Update(gameTime);
            ProjectileStorage.Update(gameTime);
            link.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            roomBuilder.Draw(_spriteBatch);
            ProjectileStorage.Draw(_spriteBatch);
            link.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}