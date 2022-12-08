using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Enemy;
using Zelda.NPCs.EnemyMultiDirection;
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
        public readonly int OLDMAN_AGRO_HEALTH = 10;
        public readonly int OLDMAN_PASSIVE_DAMAGE = 0;

        public bool Dead { get { return dead; } set { dead = value; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected INPCState state;
        protected bool dead;
        private int damage;
        protected int health;

        public INPCState State { get { return state; } set { state = value; } }
        public ISprite Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Damage { get { return damage; } }

        public OldMan(Vector2 startPosition)
        {
            sprite = NPCSpriteFactory.OldManSprite();
            position = startPosition;
            damage = OLDMAN_PASSIVE_DAMAGE;
            state = new OldManPassiveState(this);
            dead = false;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            //sprite.Update(gameTime);
        }

        bool visible = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
            }
        }

        public void Appear()
        {
            visible = true;
            AppearanceCloud cloud = new AppearanceCloud(position);
            ProjectileStorage.Add(cloud);
        }

        public void Disappear()
        {
            visible = false;
        }

        public Item DropItem()
        {
            return null;
        }
    }
}
