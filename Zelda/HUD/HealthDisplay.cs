using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;
using Zelda.Utilities;

namespace Zelda.HUD
{
    internal class HealthDisplay : IHUDElement
    {
        protected Heart[] hearts;
        public HealthDisplay()
        {
            this.hearts = new Heart[LinkUtilities.TOTAL_HEALTH];
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
