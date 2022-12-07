using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sound;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.GameStates.Classes
{
    public class TitleScreenGameState : IGameState
    {
        private Game1 game;
        private ISprite titleScreenSprite;
        
        public TitleScreenGameState(Game1 game)
        {
            this.game = game;
            titleScreenSprite = MenuSpriteFactory.TitleScreenSprite();
            game.GraphicClear();
        }

        public void Update(GameTime gameTime)
        {
            titleScreenSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            titleScreenSprite.Draw(spriteBatch, new Vector2(Settings.ROOM_WINDOW_X + 3 * Settings.BLOCK_SIZE, Settings.ROOM_WINDOW_Y));
        }

        public void LeftClick()
        {
            game.GameState = new MenuGameState(game);
            SoundManager.Instance.PlaySecretSound();
        }

        public void RightClick()
        {
            
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
