using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Collision;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.HUD;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sprites.Factories;
using Zelda.Sound;

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
        public ILink link;
        private CommandBuilder commandBuilder;
        private CollisionDetector collisionDetector;
        private IHUD hud;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = Settings.WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = Settings.WINDOW_WIDTH;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // This must be done before creating any sprite objects (items, blocks, NPCs, etc.)
            SpriteFactory.Initialize(Content);

            RoomBuilder.Instance.Initialize();
            SoundManager.Instance.Initialize(Content);

            // Create controllers
            controllers = new List<IController>();
            KeyboardController keyboard = new KeyboardController();
            MouseController mouse = new MouseController();
            controllers.Add(keyboard);
            controllers.Add(mouse);
            //SoundManager.Instance.PlayMainThemeSound();

            link = new Link1();
            commandBuilder = new CommandBuilder(keyboard, mouse, this);

            collisionDetector = new CollisionDetector();

            hud = new LinkHUD();

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
            RoomBuilder.Instance.Update(gameTime);
            RoomTransitions.Update(gameTime, link);
            ProjectileStorage.Update(gameTime);
            link.Update(gameTime);

            collisionDetector.DetectCollisions(this, gameTime, link);

            hud.Update(gameTime, link);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            RoomBuilder.Instance.Draw(_spriteBatch);
            ProjectileStorage.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            RoomBuilder.Instance.DrawTopLayer(_spriteBatch);

            hud.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}