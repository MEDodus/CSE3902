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
        public readonly int OLDMAN_AGRO_HEALTH = 5;

        public bool Dead { get { return false; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected INPCState state;
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
            damage = 0;
            state = new OldManPassiveState(this);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            //sprite.Update(gameTime);
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
