using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using Zelda.Commands;
using Zelda.Commands.Classes;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sound;
using Zelda.Sprites.Factories;
using static System.Net.Mime.MediaTypeNames;
using System;
using Color = Microsoft.Xna.Framework.Color;

namespace Zelda.GameStates.Classes
{
    public class WinningGameState : IGameState
    {
        private Game1 game;
        private TriforceLink decoratedLink;
        private double timer;
        private SpriteFont font1;
        private SpriteFont font2;

        public WinningGameState(Game1 game)
        {
            this.game = game;
            decoratedLink = new TriforceLink(game.Link, game);
            game.Link = decoratedLink;
            timer = 1.5;
            font1 = HUDSpriteFactory.winOrLoseFront();
            font2 = HUDSpriteFactory.HUDFont();


        }

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                decoratedLink.RemoveDecorator();
                //game.GameState = new RunningGameState(game); // TODO: change to win screen?
                Game1.stopAll = true;
                SoundManager.Instance.Pause();

            }
            // Update only some game objects
            RoomBuilder.Instance.Update(gameTime);
            game.Link.Update(gameTime);
            game.HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all game objects
            if (timer <= 0)
            {
                game.GraphicClear();
                spriteBatch.DrawString(font1, "YOU WIN !", new Vector2(200, 300), Color.Green);
                spriteBatch.DrawString(font2, "Press R to Restart", new Vector2(420, 550), Color.White);
            }
            else
            {
                RoomBuilder.Instance.Draw(spriteBatch);
                ProjectileStorage.Draw(spriteBatch);
                game.Link.Draw(spriteBatch);
                RoomBuilder.Instance.DrawTopLayer(spriteBatch);
                game.HUD.Draw(spriteBatch);
            }
        }
    }
}
