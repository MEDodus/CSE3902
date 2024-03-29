﻿using Microsoft.Xna.Framework;
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
using Zelda.Projectiles;
using System.Drawing;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using Zelda.Achievements;
using Microsoft.Xna.Framework.Input;
using Zelda.NPCs.FriendlyNPCs;

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
        public ILink LinkCompanion { get { return linkCompanion; } set { linkCompanion = value; } }
        public IHUD HUD { get { return hud; } set { hud = value; } }
        public CollisionDetector Collisions { get { return collisionDetector; } }
        public FriendlyNPCManager FriendlyNPCManager { get { return friendlyNPCManager; } set { friendlyNPCManager = value; } }
        public int PlayerCount { get { return playerCount; } set { playerCount = value; } }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ILink link, linkCompanion;
        private IHUD hud;
        private IGameState gameState;
        private List<IController> controllers;
        private CommandBuilder commandBuilder;
        private CollisionDetector collisionDetector;
        private FriendlyNPCManager friendlyNPCManager;
        private int playerCount;
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
            RoomBuilder.Instance.LoadLevel("Level1");
            RoomTransitions.Initialize(this);

            // Set up controllers
            controllers = new List<IController>();
            KeyboardController keyboard = new KeyboardController(this);
            MouseController mouse = new MouseController();
            controllers.Add(keyboard);
            controllers.Add(mouse);

            // Other initialization
            commandBuilder = new CommandBuilder(keyboard, mouse, this);
            collisionDetector = new CollisionDetector();
            AchievementManager.Load();
            base.Initialize();
            FriendlyNPCManager.Instance.Initialize();
            playerCount = 1;
            Reset();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public void Reset()
        {
            SoundManager.Instance.Stop();
            hud = new LinkHUD(this, new Vector2(HUDUtilities.HUD_X, HUDUtilities.HUD_Y));
            gameState = new TitleScreenGameState(this);
            RoomTransitions.Initialize(this);
            ProjectileStorage.Clear();
            link = new Link1(this, 1);
            linkCompanion = new Link1(this, 2);
            FriendlyNPCManager.Instance.FriendlyNPCs.Clear();
            base.Initialize();
        }

        public void GraphicClear()
        {
            GraphicsDevice.Clear(Color.Black);
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
            //FriendlyNPCManager.Instance.Update(this, gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicClear();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            gameState.Draw(spriteBatch);
            //FriendlyNPCManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
