using Microsoft.Xna.Framework;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;

namespace Zelda.Link
{
    internal class LinkItemHandler
    {
        public static void UseItem(int itemNum, Vector2 facingDirection, Health health, IInventory inventory, Vector2 positionInFront)
        {
            IProjectile item = null;
            IItem type = null;
            Vector2 defaultItemSpawnPos = positionInFront;
            switch (itemNum)
            {
                case 1:
                    item = new SwordBeam(defaultItemSpawnPos, facingDirection);
                    type = new Items.Classes.Sword(new Vector2());
                    break;
                case 2:
                    item = new Arrow(defaultItemSpawnPos, facingDirection);
                    type = new Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 3:
                    item = new SilverArrow(defaultItemSpawnPos, facingDirection);
                    type = new Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 4:
                    item = new Boomerang(defaultItemSpawnPos, facingDirection, ProjectileBehavior.Friendly);
                    type = new Items.Classes.Boomerang(new Vector2());
                    break;
                case 5:
                    item = new MagicalBoomerang(defaultItemSpawnPos, facingDirection);
                    type = new Items.Classes.MagicalBoomerang(new Vector2());
                    break;
                case 6:
                    item = new Bomb(positionInFront + (facingDirection * Settings.BLOCK_SIZE * (float)1.5));
                    type = new Items.Classes.Bomb(new Vector2());
                    break;
                case 7:
                    item = new CandleFlame(defaultItemSpawnPos, facingDirection);
                    type = new Items.Classes.BlueCandle(new Vector2());
                    break;
            }
            if (item != null && inventory.Contains(type) && inventory.GetItem(type).UseItem(inventory, health, defaultItemSpawnPos, facingDirection))
            {
                ProjectileStorage.Add(item);
            }
        }
    }
}
