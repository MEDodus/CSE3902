using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Link;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class PauseMenuMap : IHUDElement
    {
        private class MapTiles : DungeonHUDMap
        {
            public MapTiles(Game1 game, Rectangle destination) : base(game, destination)
            {

            }

            protected override ISprite CreateMapTile()
            {
                return HUDSpriteFactory.PauseHUDMapTile();
            }
        }

        private ISprite background;
        private MapTiles tiles;
        private Rectangle destination;

        public PauseMenuMap(Game1 game, Vector2 position)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            destination = new Rectangle(x + HUDUtilities.PAUSE_HUD_MAP_X, y + HUDUtilities.PAUSE_HUD_MAP_Y, HUDUtilities.PAUSE_HUD_MAP_WIDTH, HUDUtilities.PAUSE_HUD_MAP_HEIGHT);
            background = HUDSpriteFactory.PauseHUDMap();
            Rectangle tilesDestination = new Rectangle(x + HUDUtilities.PAUSE_HUD_MAP_TILES_X, y + HUDUtilities.PAUSE_HUD_MAP_TILES_Y, 
                HUDUtilities.PAUSE_HUD_MAP_TILES_WIDTH, HUDUtilities.PAUSE_HUD_MAP_TILES_HEIGHT);
            tiles = new(game, tilesDestination);
        }

        public void Update(GameTime gameTime, ILink link)
        {
            tiles.Update(gameTime, link);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, destination);
            tiles.Draw(spriteBatch);
        }
    }
}
