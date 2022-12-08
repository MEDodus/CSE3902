using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemy;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.NPCs.EnemyMultiDirection;

namespace Zelda.NPCs.FriendlyNPCs
{
    public class GhostFollower : IFriendlyNPC
    {
        public ISprite Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 LinkOldPosition { get { return linkOldPosition; } set { linkOldPosition = value; } }
        public Vector2 LinkPositionCopy { get { return linkPositionCopy; } set { linkPositionCopy = value; } }

        public IFriendlyNPCState State { get { return state; } set { state = value; } }

        protected Vector2 position;
        protected Vector2 linkOldPosition;
        protected Vector2 linkPositionCopy;
        protected ISprite sprite;
        protected IFriendlyNPCState state;

        private readonly double ATTACK_ANIMATION_LENGTH = 1;
        private readonly double ATTACK_COOLDOWN_LENGTH = 5;


        private double attackCooldown = 0; // seconds


        public GhostFollower()
        {
            state = new LeftMovingGhostState(this);
        }

        public void Update(Game1 game, GameTime gameTime)
        {
            this.State.Update(game, gameTime);

            this.Sprite.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
        }

    }
}
