using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zelda.Controllers
{
    public interface IController
    {
        public void RegisterCommand(Keys key, ICommand command);
        public void Update();
    }
}
