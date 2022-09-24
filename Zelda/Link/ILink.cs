using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public interface ILink
    {
        public Texture2D Texture { get; }
        public Rectangle SourceLocation { get; set; }
        public Rectangle DestinationLocation { get; set; }

        public void Update();
        public void Draw(SpriteBatch spriteBatch);

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Attack();
        void UseItem();
        void TakeDamage();
    }
}
