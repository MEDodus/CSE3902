using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public static class TextureStorage
    {
        public enum SpriteSheet
        {
            // Items and Tiles
            Tile, Arrow, SilverArrow, Bomb,
            BookOfMagic, Boomerang, MagicalBoomerang, Bow,
            BlueCandle, RedCandle, Clock, Compass,
            Fairy, Food, Heart, HeartContainer,
            Key, MagicalKey, Letter, MagicalRod,
            MagicalShield, Map, BluePotion, RedPotion,
            PowerBracelet, Raft, Recorder, BlueRing,
            RedRing, Rupy, FiveRupies, Stepladder,
            Sword, WhiteSword, Triforce, Fire, Link,

            //Enemies
            Bat, Skeleton, Goriya, JellyBlue, Hand, Spike, Snake, Dragon
        };

        private static readonly Dictionary<SpriteSheet, string> FileNames = new Dictionary<SpriteSheet, string>()
        {
            // Tiles and items
            {SpriteSheet.Tile, "tiles" },
            {SpriteSheet.Arrow, "arrow" },
            {SpriteSheet.SilverArrow, "silver_arrow" },
            {SpriteSheet.Bomb, "bomb" },
            {SpriteSheet.BookOfMagic, "book_of_magic" },
            {SpriteSheet.Boomerang, "boomerang" },
            {SpriteSheet.MagicalBoomerang, "magical_boomerang" },
            {SpriteSheet.Bow, "bow" },
            {SpriteSheet.BlueCandle, "blue_candle" },
            {SpriteSheet.RedCandle, "red_candle" },
            {SpriteSheet.Clock, "clock" },
            {SpriteSheet.Compass, "compass" },
            {SpriteSheet.Fairy, "fairy" },
            {SpriteSheet.Food, "food" },
            {SpriteSheet.Heart, "heart" },
            {SpriteSheet.HeartContainer, "heart_container" },
            {SpriteSheet.Key, "key" },
            {SpriteSheet.MagicalKey, "magical_key" },
            {SpriteSheet.Letter, "letter" },
            {SpriteSheet.MagicalRod, "magical_rod" },
            {SpriteSheet.MagicalShield, "magical_shield" },
            {SpriteSheet.Map, "map" },
            {SpriteSheet.BluePotion, "blue_potion" },
            {SpriteSheet.RedPotion, "red_potion" },
            {SpriteSheet.PowerBracelet, "power_bracelet" },
            {SpriteSheet.Raft, "raft" },
            {SpriteSheet.Recorder, "recorder" },
            {SpriteSheet.BlueRing, "blue_ring" },
            {SpriteSheet.RedRing, "red_ring" },
            {SpriteSheet.Rupy, "rupy" },
            {SpriteSheet.FiveRupies, "five_rupies" },
            {SpriteSheet.Stepladder, "stepladder" },
            {SpriteSheet.Sword, "sword" },
            {SpriteSheet.WhiteSword, "white_sword" },
            {SpriteSheet.Triforce, "triforce" },
            {SpriteSheet.Fire, "fire" },
            {SpriteSheet.Link, "link" },

            //Enemies
            {SpriteSheet.Bat, "bat" },
            {SpriteSheet.Skeleton, "skeleton" },
            {SpriteSheet.Goriya, "goriya" },
            {SpriteSheet.JellyBlue, "JellyBlue" },
            {SpriteSheet.Hand, "hand" },
            {SpriteSheet.Spike, "spike_cross" },
            {SpriteSheet.Snake, "snake" },
            {SpriteSheet.Dragon, "dragon" }


        };

        private static readonly Dictionary<SpriteSheet, Texture2D> Textures = new Dictionary<SpriteSheet, Texture2D>();

        public static void LoadContent(ContentManager content)
        {
            foreach (KeyValuePair<SpriteSheet, string> pair in FileNames)
            {
                Texture2D texture = content.Load<Texture2D>("spritesheets\\" + pair.Value);
                Textures.Add(pair.Key, texture);
            }
        }

        public static Texture2D GetTexture(SpriteSheet sheetName)
        {
            return Textures.GetValueOrDefault(sheetName);
        }
    }

}
