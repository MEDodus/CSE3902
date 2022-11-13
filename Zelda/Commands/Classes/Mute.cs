using Microsoft.Xna.Framework;
using Zelda.Sound;

namespace Zelda.Commands
{
    public class Mute : ICommand
    {
        public Mute()
        {

        }

        public void Execute(GameTime gametime)
        {
            SoundManager.Instance.toggleMute();
        }
    }
}