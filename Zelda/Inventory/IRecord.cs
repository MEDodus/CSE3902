using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Inventory
{
    /* Wrapper interface around items */
    public interface IRecord
    {
        public void AddToQuantity(int amount);
    }
}
