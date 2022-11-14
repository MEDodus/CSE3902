﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Projectiles;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class TriforceLink : ILink
    {
        public ILinkState State { get => decoratedLink.State; set => decoratedLink.State = value; }
        public ISprite Sprite { get => decoratedLink.Sprite; set => decoratedLink.Sprite = value; }
        public Vector2 Position { get => decoratedLink.Position; set => decoratedLink.Position = value; }
        public Vector2 Direction { get => decoratedLink.Direction; }
        public Health Health { get => decoratedLink.Health; }
        public IInventory Inventory { get => decoratedLink.Inventory; }

        Game1 game;
        ILink decoratedLink;
        ISprite originalSprite;

        private readonly Vector2 OFFSET = new Vector2(0, Settings.BLOCK_SIZE * 0.8f);

        public TriforceLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            State = new LinkFacingDownState(decoratedLink);
            originalSprite = decoratedLink.Sprite;
            decoratedLink.Sprite = LinkSpriteFactory.LinkTriforceSprite();
            this.game = game;
            Position -= OFFSET;
        }
        public void Update(GameTime gameTime)
        {
            decoratedLink.Update(gameTime);
        }

        public void Reset()
        {
            decoratedLink.Reset();
            RemoveDecorator();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }

        public void MoveUp()
        {
            // Can't move when holding triforce
        }
        public void MoveDown()
        {
            // Can't move when holding triforce
        }
        public void MoveLeft()
        {
            // Can't move when holding triforce
        }
        public void MoveRight()
        {
            // Can't move when holding triforce
        }
        public void TakeDamage(Game1 game, int damage, Vector2 direction)
        {
            // Can't take when holding triforce
        }

        public void UseItem(int itemNum)
        {
            // Can't use items when holding triforce
        }

        public void CreateItem(int itemNum)
        {
            // Can't create items when holding triforce
        }

        public bool AddToInventory(IItem item)
        {
            // Can't equip items when holding triforce
            return false;
        }

        public void RemoveDecorator()
        {
            Position += OFFSET;
            decoratedLink.Sprite = originalSprite;
            game.Link = decoratedLink;
        }
    }
}
