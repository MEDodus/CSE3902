using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Borders.Classes;
using Zelda.Rooms;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Borders
{
    public abstract class IBorder
    {
        public bool Locked { get { return locked; } }

        protected Room room;
        protected ISprite sprite;
        protected Vector2 absolutePosition;
        protected Vector2 size;
        protected bool locked;

        public IBorder(Room room, ISprite sprite, bool locked, Vector2 relativePosition, Vector2 size)
        {
            this.room = room;
            this.sprite = sprite;
            absolutePosition = room.Position + relativePosition;
            this.size = size;
            this.locked = locked;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 offset = RoomBuilder.Instance.WindowOffset;
            sprite.Draw(spriteBatch, new Rectangle((int)(absolutePosition.X + offset.X), (int)(absolutePosition.Y + offset.Y), (int)size.X, (int)size.Y));
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Unlock()
        {
            locked = false;
            sprite.Texture = SpriteFactory.GetTexture("borders_doors_open");
        }
    }
}
