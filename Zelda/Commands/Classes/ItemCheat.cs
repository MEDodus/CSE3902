using Microsoft.Xna.Framework;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Utilities;

namespace Zelda.Commands
{
    public class ItemCheat : ICommand
    {
        private Game1 game;
        private int itemNumber;

        public ItemCheat(Game1 game, int number)
        {
            this.game = game;
            itemNumber = number;
        }

        public void Execute(GameTime gametime)
        {
            if(itemNumber == 0)
            {
                game.Link.Inventory.AddItem(new Map(new Vector2()), 1);
            } else if (itemNumber == 1)
            {
                game.Link.Inventory.AddItem(new Compass(new Vector2()), 1);
            } else if (itemNumber == 2)
            {
                game.Link.Inventory.AddItem(new Boomerang(new Vector2()), 1);
            } else if (itemNumber == 3)
            {
                game.Link.Inventory.AddItem(new Bomb(new Vector2()), LinkUtilities.BOMB_ITEM_PICKUP_AMOUNT);
            } else if (itemNumber == 4)
            {
                game.Link.Inventory.AddItem(new Bow(new Vector2()), 1);
            } else if (itemNumber == 5)
            {
                game.Link.Inventory.AddItem(new BlueCandle(new Vector2()), 1);
            } else if (itemNumber == 6)
            {
                game.Link.Inventory.AddItem(new Recorder(new Vector2()), 1);
            } else if (itemNumber == 7)
            {
                game.Link.Inventory.AddItem(new Food(new Vector2()), 1);
            } else if (itemNumber == 8)
            {
                game.Link.Inventory.AddItem(new BluePotion(new Vector2()), 1);
            } else if (itemNumber == 9)
            {
                game.Link.Inventory.AddItem(new MagicalRod(new Vector2()), 1);
            }
        }
    }
}