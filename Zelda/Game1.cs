using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Zelda.Blocks;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.Items;
using Zelda.Link;
using Zelda.NPCs;
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
        private CommandBuilder commandBuilder;
        private ItemBuilder itemBuilder;
        private BlockBuilder blockBuilder;
        private NPCBuilder npcBuilder;
        public ILink link;
        private IRoom room;
        private Viewport viewport;

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
            viewport = _graphics.GraphicsDevice.Viewport;

            // Create controllers
            controllers = new List<IController>();
            KeyboardController keyboard = new KeyboardController();
            controllers.Add(keyboard);

            link = new Link2();
            // Create object builders (for sprint 2 only)
            itemBuilder = new ItemBuilder();
            blockBuilder = new BlockBuilder();
            npcBuilder = new NPCBuilder();
            commandBuilder = new CommandBuilder(keyboard, this, itemBuilder, blockBuilder, npcBuilder, link);
            room = new GridRoom("../../../RoomFiles/block.csv", viewport);

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
            itemBuilder.Update(gameTime);
            blockBuilder.Update(gameTime);
            npcBuilder.Update(gameTime);
            link.Update();
            ProjectileStorage.Update(gameTime);

            // Testing room
            room.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            itemBuilder.Draw(_spriteBatch);
            blockBuilder.Draw(_spriteBatch);
            npcBuilder.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            ProjectileStorage.Draw(_spriteBatch);

            // Testing room
            room.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}