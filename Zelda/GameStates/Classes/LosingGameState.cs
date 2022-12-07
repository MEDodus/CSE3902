using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sound;
using Zelda.Sprites.Factories;
using Color = Microsoft.Xna.Framework.Color;

namespace Zelda.GameStates.Classes
{
    public class LosingGameState : IGameState
    {
        private Game1 game;
        private SpriteFont font1;
        private SpriteFont font2;

        public LosingGameState(Game1 game)
        {
            this.game = game;
            font1 = HUDSpriteFactory.WinOrLoseFont();
            font2 = HUDSpriteFactory.HUDFont();
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayLinkDieSound();
            game.GraphicClear();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font1, "LINK DIED !", new Vector2(170, 260), Color.Red);
            spriteBatch.DrawString(font2, "Click to continue", new Vector2(420, 550), Color.White);
        }

        public void LeftClick()
        {
            game.Reset(); // TODO: don't reset link inventory
            game.GameState = new MenuGameState(game);
        }

        public void RightClick()
        {
            game.Reset(); // TODO: don't reset link inventory
            game.GameState = new MenuGameState(game);
        }

        public void Up()
        {
            
        }

        public void Down()
        {
            
        }

        public void Left()
        {
            
        }

        public void Right()
        {
            
        }
    }
}
