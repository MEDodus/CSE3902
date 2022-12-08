using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;

namespace Zelda.ItemEffects
{
    public class ItemTimer
    {

        public int Duration { get; set; }
        public Item Item { get; set; }

        private int duration;
        private Item item;

        public ItemTimer()
        {
            duration = 0;
            item = null;
        }

        public bool HasExpired()
        {
            return duration <= 0;
        }

        public bool IsStar()
        {
            return item is Star;
        }

        public bool IsMushroom()
        {
            return item is Mushroom;
        }

        public void Decrement()
        {
            duration -= 1;
        }

        public void UtilizeEffect(ILinkState state)
        {
            if (state is LinkMovingUpState)
            {
                ((LinkMovingUpState)state).Update(Settings.SPEED_MULT);
            }
            else if (state is LinkMovingDownState)
            {
                ((LinkMovingDownState)state).Update(Settings.SPEED_MULT);
            }
            else if (state is LinkMovingLeftState)
            {
                ((LinkMovingLeftState)state).Update(Settings.SPEED_MULT);
            }
            else if (state is LinkMovingRightState)
            {
                ((LinkMovingRightState)state).Update(Settings.SPEED_MULT);
            }
            else
            {
                state.Update();
            }
        }
    }
}
