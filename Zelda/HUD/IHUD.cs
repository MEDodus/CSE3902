using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.HUD
{
    internal interface IHUD
    {
        public void Update();
        public void Draw();
    }
}
