using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;




namespace Zelda.Sprites
{
    public class Tiles
    {
        // Tiles in sprite sheet are always 16x16
        private readonly int TILESIZE = 16;

        // Rows and Cols for sprite sheet are 2 and 5
        private readonly int ROWS = 2;
        private readonly int COLS = 5;

        private ISprite[] tiles;
        private Texture2D tileSheet;
        private int idx;

        public ISprite GetTile { get { return tiles[idx]; } }
        
        public Tiles()
        {
            this.tileSheet = TextureStorage.GetTexture(TextureStorage.SpriteSheet.Tile);
            this.tiles = new Tile[ROWS * COLS];
            this.idx = 0;
            InitTiles();
        }

        public void InitTiles()
        {
            int numTiles = ROWS * COLS, r = 0;
            for (int i = 0; i < numTiles; i++)
            {
                if (i == 0)
                {
                    r = 0;
                }
                else
                {
                    r = COLS / i;
                }
                int c = i % COLS;
                tiles[i] = new Tile(new Rectangle(c * TILESIZE, r * TILESIZE, TILESIZE, TILESIZE), new Rectangle(50, 50, TILESIZE, TILESIZE));
            }
        }


        public void PreviousTile()
        {
            if (idx == 0)
            {
                idx = tiles.Length - 1;
            }
            else
            {
                idx--;
            }
        }

        public void NextTile()
        {
            if (idx == tiles.Length - 1)
            {
                idx = 0;
            } else
            {
                idx++;
            }
        }

        public void Reset()
        {
            idx = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ISprite tile = tiles[idx];
            spriteBatch.Begin();
            spriteBatch.Draw(tileSheet, tile.DestinationLocation, tile.SourceLocation, Color.White);
            spriteBatch.End();
        }
    }
}
