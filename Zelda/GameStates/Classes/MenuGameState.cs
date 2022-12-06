using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zelda.GameStates.Classes
{
    public class MenuGameState : IGameState
    {
        private Game1 game;
        // when entering menu, left click is already down from the title screen, so wait to accept input
        private double clickCooldown = 0.75;

        public MenuGameState(Game1 game)
        {
            this.game = game;
            // TODO: create buttons
            game.GraphicClear();
        }

        public void Update(GameTime gameTime)
        {
            if (clickCooldown > 0)
            {
                clickCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: draw buttons
        }

        public void LeftClick()
        {
            if (clickCooldown > 0)
            {
                return;
            }
            Point position = Mouse.GetState().Position;
            // TODO: check if mouse position is within bounds of different buttons, enter different game states if so
            // possibly play a click sfx if a button is pressed
            game.GameState = new RunningGameState(game);
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
