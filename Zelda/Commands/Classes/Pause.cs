using Microsoft.Xna.Framework;
using Zelda.GameStates.Classes;
using Zelda.Sound;

namespace Zelda.Commands.Classes
{
    public class Pause : ICommand
    {
        private Game1 game;

        public Pause(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            bool paused = game.GameState is PausedGameState;
            game.GameState = paused ? new RunningGameState(game) : new PausedGameState(game);
            SoundManager.Instance.muteAndUnmute(!paused);
        }
    }
}
