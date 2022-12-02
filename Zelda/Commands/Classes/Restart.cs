using Microsoft.Xna.Framework;
using Zelda.GameStates.Classes;
using Zelda.Projectiles;
using Zelda.Sound;

namespace Zelda.Commands.Classes
{
    public class Restart : ICommand
    {
        private Game1 game;

        public Restart(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            Game1.stopAll = false;
            SoundManager.Instance.Resume();
            game.Reset();
            game.GameState = new RunningGameState(game);
        }
    }
}