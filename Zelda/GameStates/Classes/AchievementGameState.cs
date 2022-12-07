using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.Menu;
using Zelda.Sound;

namespace Zelda.GameStates.Classes
{
    public class AchievementGameState : IGameState
    {
        private Game1 game;
        private double clickCooldown = 0.5; // when entering screen, left click is already down from the main menu, so wait to accept input
        private BackButton backButton;

        public AchievementGameState(Game1 game)
        {
            this.game = game;
            game.GraphicClear();
            backButton = new BackButton(new Vector2(100, 100));
            // TODO: create list/grid of achievements, link this to an AchievementManager class or something
        }

        public void Update(GameTime gameTime)
        {
            if (clickCooldown > 0)
            {
                clickCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            backButton.Update(gameTime);
            // TODO: update achievement list
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backButton.Draw(spriteBatch);
            // TODO: draw achievement list
        }

        public void LeftClick()
        {
            if (clickCooldown > 0)
            {
                return;
            }
            Point position = Mouse.GetState().Position;
            if (backButton.Destination.Contains(position))
            {
                SoundManager.Instance.PlayMenuClickSound();
                game.GameState = new MenuGameState(game);
            }
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
