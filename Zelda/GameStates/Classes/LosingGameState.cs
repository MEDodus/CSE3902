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
    public class LosingGameState : IGameState
    {
        private Game1 game;
        //private TriforceLink decoratedLink;
        private SpriteFont font1;
        private SpriteFont font2;

        public LosingGameState(Game1 game)
        {
            this.game = game;
            font1 = HUDSpriteFactory.winOrLoseFront();
            font2 = HUDSpriteFactory.HUDFont();
            Game1.stopAll = true;
            SoundManager.Instance.Pause();

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicClear();
            spriteBatch.DrawString(font1, "LINK DIED !", new Vector2(170, 260), Color.Red);
            spriteBatch.DrawString(font2, "Press R to Restart", new Vector2(420, 550), Color.White);

        }
    }
}
