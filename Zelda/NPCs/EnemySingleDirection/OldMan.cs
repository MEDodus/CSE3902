using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Items;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Rooms;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class OldMan : INPC
    {
        public ISprite Sprite { get { return sprite; } }
        public bool Dead { get { return false; } }
        public int Damage { get { return damage; } }

        protected ISprite sprite;
        protected Vector2 position;
        private int damage;

        public OldMan(Vector2 startPosition)
        {
            sprite = NPCSpriteFactory.OldManSprite();
            position = startPosition;
            damage = 0;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        bool appeared = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
            if (!appeared)
            {
                appeared = true;
                AppearanceCloud cloud = new AppearanceCloud(position);
                cloud.Draw(spriteBatch);
                ProjectileStorage.Add(new AppearanceCloud(position));
            }
        }

        public IItem DropItem()
        {
            return null;
        }
    }
}
