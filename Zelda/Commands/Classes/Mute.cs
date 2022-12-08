using Microsoft.Xna.Framework;
using Zelda.GameStates;
using Zelda.GameStates.Classes;
using Zelda.Sound;

namespace Zelda.Commands
{
    public class Mute : ICommand
    {
        private Game1 game;

        public Mute(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            SoundManager.Instance.ToggleMute();
            if (!SoundManager.Instance.Muted)
            {
                IGameState state = game.GameState;
                if (state is RunningGameState || state is PausedGameState)
                {
                    SoundManager.Instance.PlayDungeonThemeSound();
                }
                else if (state is TitleScreenGameState || state is MenuGameState || state is AchievementGameState || state is LevelSelectGameState)
                {
                    SoundManager.Instance.PlayMainThemeSound();
                }
            }
        }
    }
}