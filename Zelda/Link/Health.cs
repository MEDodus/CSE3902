
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Utilities;

namespace Zelda.Link
{
    public class Health
    {
        public int CurrentHealth { get { return playerHealth; } }
        public int MaxHealth { get { return maxPlayerHealth; } }

        private int playerHealth;
        private int maxPlayerHealth;
        public Health()
        {
            playerHealth = LinkUtilities.MAX_HEALTH_START;
            maxPlayerHealth = LinkUtilities.MAX_HEALTH_START;
        }

        public void removeHealth(int health)
        {
            playerHealth -= health;
            if(playerHealth <= 0)
            {
                // Trigger link death
            }
        }

        public void addHealth(int health)
        {
            if (playerHealth + health > maxPlayerHealth)
            {
                healthToFull();
            } else
            {
                playerHealth += health;
            }
        }

        public void healthToFull()
        {
            playerHealth = maxPlayerHealth;
        }

        public void addMaxHealth(int health)
        {
            if(maxPlayerHealth + health > LinkUtilities.MAX_HEARTS * 2)
            {
                maxPlayerHealth = LinkUtilities.MAX_HEARTS * 2;
            } else
            {
                maxPlayerHealth += health;
            }
        }

    }
}
