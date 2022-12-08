﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml;
using Zelda.Inventory;
using Zelda.ItemEffects;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Items
{
    public abstract class Item
    {

        public static readonly int INFINITE = int.MaxValue, ONE = 1;
        public ISprite Sprite { get { return sprite; } }
        public int MaxItemCount { get { return maxItemCount; } }
        public Vector2 Position { get { return position; } set { position = value; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected int maxItemCount;
        protected int quantityHeld;
        protected IEffect effect;

        public int QuantityHeld { get { return quantityHeld; } }

        public Item(ISprite sprite, Vector2 position, int maxItemCount, IEffect effect)
        {
            this.sprite = sprite;
            this.position = position;
            this.maxItemCount = maxItemCount;
            this.effect = effect;
            quantityHeld = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
        }

        public bool AddToQuantity(int amount)
        {
            int newQuantity = quantityHeld + amount;
            if (newQuantity > MaxItemCount)
            {
                quantityHeld = MaxItemCount;
            }
            else
            {
                quantityHeld = newQuantity;
            }
            return true;
            // Implement false condition for other game inventory conditions if needed
        }

        /* 
         * True if we successfully removed amount from item capacity,
         * false if we can't or results in zero or negative item capacity
         */
        public bool UseItem(IInventory inventory, ILink link, Vector2 position, Vector2 facingDirection)
        {
            return effect.UseEffect(this, inventory, link, position, facingDirection);
        }

        public virtual Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            // Most items do not have a projectile counterpart
            return null;
        }
    }
}