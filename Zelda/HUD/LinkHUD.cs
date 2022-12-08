using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameStates.Classes;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Rooms;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class LinkHUD : IHUD
    {
        private Game1 game;
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected PauseMenuMap pauseMenuMap;
        protected HealthDisplay healthDisplay;
        protected IHUDElement rupyQuantity;
        protected IHUDElement keyQuantity;
        protected IHUDElement bombQuantity;
        protected IHUDElement itemSelectionBox;
        protected HUDItem slotA;
        protected HUDItem slotB;
        protected HUDItem pauseItem;
        protected Vector2 HUDPosition;
        protected SpriteFont font;

        public LinkHUD(Game1 game, Vector2 position)
        {
            HUDPosition = position;
            this.game = game;
            hudBackground = new HUDBackground(HUDSpriteFactory.LinkHUDBackground(), position);
            map = new DungeonHUDMap(game, new Rectangle((int)position.X + HUDUtilities.MAP_X, (int)position.Y + HUDUtilities.MAP_Y, 
                HUDUtilities.MAP_WIDTH, HUDUtilities.MAP_HEIGHT));
            pauseMenuMap = new PauseMenuMap(game, position);
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay(position);
            rupyQuantity = new HUDRupyQuantity(new FiveRupies(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.RUPY_COUNT_Y));
            keyQuantity = new HUDItemQuantity(new Key(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.KEY_COUNT_Y));
            bombQuantity = new HUDItemQuantity(new Bomb(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.SECONDARY_COUNT_Y));
            itemSelectionBox = new ItemSelectionBox();
            slotA = new HUDItem(new Sword(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_A_X, HUDUtilities.SLOT_Y));
            font = HUDSpriteFactory.HUDFont();
        }
        public void Update(GameTime gameTime)
        {
            ILink link = game.Link;
            hudBackground.Update(gameTime, link);
            map.Update(gameTime, link);
            pauseMenuMap.Update(gameTime, link);
            healthDisplay.Update(gameTime, link);
            rupyQuantity.Update(gameTime, link);
            keyQuantity.Update(gameTime, link);
            bombQuantity.Update(gameTime, link);
            itemSelectionBox.Update(gameTime, link);
            slotA.Update(gameTime, link);
            IItem secondary = link.Inventory.Secondary;
            if (secondary != null)
            {
                slotB = new HUDItem(secondary, HUDPosition + new Vector2(HUDUtilities.SLOT_B_X, HUDUtilities.SLOT_Y));
                if (game.GameState is PausedGameState)
                {
                    pauseItem = new HUDItem(secondary, HUDPosition + new Vector2(HUDUtilities.PAUSE_SECONDARY_ITEM_X, HUDUtilities.PAUSE_SECONDARY_ITEM_Y));
                }
            }
            else
            {
                slotB = null;
                pauseItem = null;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            BlackBorders.Draw(spriteBatch);
            hudBackground.Draw(spriteBatch);
            map.Draw(spriteBatch);
            if (game.Link.Inventory.Contains(new Map(new Vector2())))
            {
                pauseMenuMap.Draw(spriteBatch);
            }
            healthDisplay.Draw(spriteBatch);
            rupyQuantity.Draw(spriteBatch);
            keyQuantity.Draw(spriteBatch);
            bombQuantity.Draw(spriteBatch);
            if (game.GameState is PausedGameState)
            {
                itemSelectionBox.Draw(spriteBatch);
            }
            slotA.Draw(spriteBatch);
            if (slotB != null)
            {
                slotB.Draw(spriteBatch);
            }
            if (pauseItem!= null)
            {
                pauseItem.Draw(spriteBatch);
            }
            spriteBatch.DrawString(font, RoomBuilder.Instance.CurrentLevel.ToUpper(), HUDPosition + HUDUtilities.LEVEL_TEXT_OFFSET, Color.White);
        }
    }
}
