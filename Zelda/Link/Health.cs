
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Sound;
using Zelda.Utilities;
using Zelda.GameStates;
using Zelda.GameStates.Classes;

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

        public void removeHealth(int health, Game1 game)
        {
            playerHealth -= health;
            if(playerHealth <= 0)
            {
                game.GameState = new LosingGameState(game);
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
