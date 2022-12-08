using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Link
{
    public static class LinkMovementUtil
    {
        public static bool IsMovingState(ILinkState state)
        {
            return state is LinkMovingDownState || state is LinkMovingLeftState || state is LinkMovingRightState || state is LinkMovingUpState;
        }
    }
}
