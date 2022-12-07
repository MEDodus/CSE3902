using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.NPCs
{
    public static class EnemyCounter
    {
        public static readonly int mod = 10;
        public static int count = 0;
        public static int Count { get { return count; } set { count = value; } }
        public static void Increment()
        {
            count++;
            count %= mod;
        }
    }
}
