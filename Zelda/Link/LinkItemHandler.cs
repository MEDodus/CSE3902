using System;
using Microsoft.Xna.Framework;
using System.Linq;

using Zelda.Items;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Inventory;

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
                    type = new Zelda.Items.Classes.Sword(new Vector2());
                    break;
                case 2:
                    item = new Projectiles.Classes.Arrow(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 3:
                    item = new Projectiles.Classes.SilverArrow(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 4:
                    item = new Projectiles.Classes.Boomerang(defaultItemSpawnPos, facingDirection, ProjectileBehavior.Friendly);
                    type = new Zelda.Items.Classes.Boomerang(new Vector2());
                    break;
                case 5:
                    item = new Projectiles.Classes.MagicalBoomerang(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.MagicalBoomerang(new Vector2());
                    break;
                case 6:
                    item = new Projectiles.Classes.Bomb(positionInFront + (facingDirection * Settings.BLOCK_SIZE * (float)1.5));
                    type = new Zelda.Items.Classes.Bomb(new Vector2());
                    break;
                case 7:
                    item = new CandleFlame(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.BlueCandle(new Vector2());
                    break;
            }
            if (item != null && inventory.Contains(type) && inventory.GetItem(type).UseItem(inventory, health, defaultItemSpawnPos, facingDirection))
            {
                ProjectileStorage.Add(item);
            }
        }
    }
}
