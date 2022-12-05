using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Collision;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.HUD;
using Zelda.Link;
using Zelda.Rooms;
using Zelda.Sprites.Factories;
using Zelda.Sound;
using Zelda.GameStates;
using Zelda.GameStates.Classes;
using Zelda.Utilities;
using System;
using Zelda.Projectiles;

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
        public IGameState GameState { get { return gameState; } set { gameState = value; } }
        public ILink Link { get { return link; } set { link = value; } }
        public IHUD HUD { get { return hud; } }
        public CollisionDetector Collisions { get { return collisionDetector; } }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ILink link;
        private IHUD hud;
        private IGameState gameState;
        private List<IController> controllers;
        private CommandBuilder commandBuilder;
        private CollisionDetector collisionDetector;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Settings.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = Settings.WINDOW_WIDTH;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // This must be done before creating any content-dependent objects
            SpriteFactory.Initialize(Content);
            SoundManager.Instance.Initialize(Content);
            RoomBuilder.Instance.Initialize();
            RoomTransitions.Initialize(this);

            // Set up controllers
            controllers = new List<IController>();
            KeyboardController keyboard = new KeyboardController(this);
            MouseController mouse = new MouseController();
            controllers.Add(keyboard);
            controllers.Add(mouse);

            // Other initialization
            link = new Link1();
            hud = new LinkHUD(this, new Vector2(HUDUtilities.HUD_X, HUDUtilities.HUD_Y));
            commandBuilder = new CommandBuilder(keyboard, mouse, this);
            collisionDetector = new CollisionDetector();
            gameState = new TitleScreenGameState(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // All controllers must be updated regardless of game state so state transitions can occur
            foreach (IController controller in controllers)
            {
                controller.Update(gameTime);
            }
            gameState.Update(gameTime);
            base.Update(gameTime);
        }

        public void Reset()
        {
            // Other initialization
            hud = new LinkHUD(this, new Vector2(HUDUtilities.HUD_X, HUDUtilities.HUD_Y));
            gameState = new RunningGameState(this);
            SoundManager.Instance.Resume();
            RoomBuilder.Instance.Reset();
            RoomTransitions.Initialize(this);
            ProjectileStorage.Clear();
            link = new Link1();
            base.Initialize();
        }

        public void GraphicClear()
        {
            GraphicsDevice.Clear(Color.Black);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicClear();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            gameState.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}