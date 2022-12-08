using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Enemy;
using Zelda.NPCs.EnemyMultiDirection;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Rooms;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class OldMan : INPC
    {
        public readonly int OLDMAN_AGRO_HEALTH = 1;
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

    }
}
