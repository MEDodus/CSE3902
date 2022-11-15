using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Rooms;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.HUD
{
    public class DungeonHUDMap : IHUDElement
    {
        private readonly int PIXELS_BETWEEN_TILES = 0;

        private Game1 game;
        private Rectangle mapDestination;
        private Dictionary<ISprite, Rectangle> mapTiles; // values are the destination rectangles
        private ISprite roomIndicator;
        private Vector2 roomIndicatorPosition;
        private ISprite triforceIndicator;
        private Vector2 triforceIndicatorPosition;

        private int dungeonWidthInPixels;
        private int dungeonHeightInPixels;
        private int dungeonWidthInRooms;
        private int dungeonHeightInRooms;
        private int tileWidth;
        private int tileHeight;

        public DungeonHUDMap(Game1 game, Rectangle destination)
        {
            this.game = game;
            mapDestination = destination;
            mapTiles = new();
            roomIndicator = HUDSpriteFactory.RoomIndicator();
            triforceIndicator = HUDSpriteFactory.RoomIndicator();
            CreateMapTiles();
        }

        public void Update(GameTime gameTime, ILink link)
        {
            roomIndicatorPosition = IndicatorPosition(RoomBuilder.Instance.CurrentRoom);
            triforceIndicatorPosition = IndicatorPosition(RoomBuilder.Instance.GetRoom("Room4"));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.Link.Inventory.Contains(new Map(new Vector2())))
            {
                foreach (KeyValuePair<ISprite, Rectangle> pair in mapTiles)
                {
                    pair.Key.Draw(spriteBatch, pair.Value);
                }
            }
            if (game.Link.Inventory.Contains(new Compass(new Vector2())))
            {
                triforceIndicator.Draw(spriteBatch, triforceIndicatorPosition, Color.Orange);
            }
            roomIndicator.Draw(spriteBatch, roomIndicatorPosition, Color.GreenYellow);
        }

        private void CreateMapTiles()
        {
            // Get the top left and bottom right global coordinates of the dungeon
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            foreach (Room room in RoomBuilder.Instance.Rooms)
            {
                Vector2 roomPosition = room.Position;
                int x = (int)roomPosition.X;
                int y = (int)roomPosition.Y;
                minX = Math.Min(x, minX);
                minY = Math.Min(y, minY);
                maxX = Math.Max(x + Settings.ROOM_WINDOW_WIDTH, maxX);
                maxY = Math.Max(y + Settings.ROOM_WINDOW_HEIGHT, maxY);
            }
            // Calculate width/height of dungeon in both pixels and rooms
            dungeonWidthInPixels = maxX - minX;
            dungeonHeightInPixels = maxY - minY;
            dungeonWidthInRooms = dungeonWidthInPixels / Settings.ROOM_WINDOW_WIDTH;
            dungeonHeightInRooms = dungeonHeightInPixels / Settings.ROOM_WINDOW_HEIGHT;
            // Create the map tiles and store their destination rectangles
            tileWidth = (mapDestination.Width - (dungeonWidthInRooms - 1) * PIXELS_BETWEEN_TILES) / dungeonWidthInRooms;
            tileHeight = (mapDestination.Height - (dungeonHeightInRooms - 1) * PIXELS_BETWEEN_TILES) / dungeonHeightInRooms;
            foreach (Room room in RoomBuilder.Instance.Rooms)
            {
                if (room.Name.Equals("Room17") || room.Name.Equals("Room18"))
                {
                    continue;
                }
                ISprite tile = CreateMapTile();
                Vector2 mapPosition = DungeonToMapPosition(room.Position);
                Rectangle tileDestination = new Rectangle((int)mapPosition.X, (int)mapPosition.Y, tileWidth, tileHeight);
                mapTiles.Add(tile, tileDestination);
            }
        }

        protected virtual ISprite CreateMapTile()
        {
            return HUDSpriteFactory.DungeonHUDMapTile();
        }

        protected Vector2 DungeonToMapPosition(Vector2 dungeonPosition)
        {
            int x = (int)dungeonPosition.X * mapDestination.Width / dungeonWidthInPixels + mapDestination.X;
            int y = (int)dungeonPosition.Y * mapDestination.Height / dungeonHeightInPixels + mapDestination.Y;
            return new Vector2(x, y);
        }

        protected Vector2 IndicatorPosition(Room room)
        {
            Vector2 mapPosition = DungeonToMapPosition(room.Position);
            Vector2 indicatorSize = new Vector2(roomIndicator.Destination.Width, roomIndicator.Destination.Height);
            return mapPosition + new Vector2(tileWidth / 2, tileHeight / 2 - 1) - indicatorSize / 2;
        }
    }
}
