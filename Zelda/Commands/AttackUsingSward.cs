using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;

namespace Zelda.Commands
{
    public class AttackUsingSward : ICommand
    {
        private Game1 game;
        private ILink link;

        public AttackUsingSward(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute()
        {
            link.AttackUsingSward();
        }
    }
}
