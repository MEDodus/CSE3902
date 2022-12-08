using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Link;
using Zelda.Inventory;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class ItemSelectionBox : IHUDElement
    {
        private ISprite sprite;
        private Rectangle destination;
        
        public ItemSelectionBox()
        {
            sprite = HUDSpriteFactory.ItemSelectSprite();
        }

        public void Update(GameTime gameTime, ILink link)
        {
            int index = link.Inventory.SecondaryIndex;
            int row = index / 4;
            int col = index % 4;
            int size = HUDUtilities.SELECTION_BOX_SIZE;
            int x = HUDUtilities.SELECTION_BOX_X + col * (size + HUDUtilities.SELECTION_BOX_OFFSET_X);
            int y = HUDUtilities.SELECTION_BOX_Y + row * (size + HUDUtilities.SELECTION_BOX_OFFSET_Y);
            destination = new Rectangle(x, y, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destination);
        }
    }
}
