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
            Sword, WhiteSword, Triforce, Fire
        };

        private static readonly Dictionary<SpriteSheet, string> FileNames = new Dictionary<SpriteSheet, string>()
        {
            // Items and Tiles
            {SpriteSheet.Tile, "TILE SPRITESHEET FILE" }, {SpriteSheet.Arrow, "ARROW SPRITESHEET FILE" },
            {SpriteSheet.SilverArrow, "SILVER ARROW SPRITESHEET FILE" }, {SpriteSheet.Bomb, "BOMB SPRITESHEET FILE" },
            {SpriteSheet.BookOfMagic, "BOOK OF MAGIC SPRITESHEET FILE" }, {SpriteSheet.Boomerang, "BOOMERANG SPRITESHEET FILE" },
            {SpriteSheet.MagicalBoomerang, "MAGICAL BOOMERANG SPRITESHEET FILE" }, {SpriteSheet.Bow, "BOW SPRITESHEET FILE" },
            {SpriteSheet.BlueCandle, "BLUE CANDLE SPRITESHEET FILE" }, {SpriteSheet.RedCandle, "RED CANDLE SPRITESHEET FILE" },
            {SpriteSheet.Clock, "CLOCK SPRITESHEET FILE" }, {SpriteSheet.Compass, "COMPASS SPRITESHEET FILE" },
            {SpriteSheet.Fairy, "FAIRY SPRITESHEET FILE" }, {SpriteSheet.Food, "FOOD SPRITESHEET FILE" },
            {SpriteSheet.Heart, "HEART SPRITESHEET FILE" }, {SpriteSheet.HeartContainer, "HEART CONTAINER SPRITESHEET FILE" },
            {SpriteSheet.Key, "KEY SPRITESHEET FILE" }, {SpriteSheet.MagicalKey, "MAGICAL KEY SPRITESHEET FILE" },
            {SpriteSheet.Letter, "LETTER SPRITESHEET FILE" }, {SpriteSheet.MagicalRod, "MAGICAL ROD SPRITESHEET FILE" },
            {SpriteSheet.MagicalShield, "MAGICAL SHIELD SPRITESHEET FILE" }, {SpriteSheet.Map, "MAP SPRITESHEET FILE" },
            {SpriteSheet.BluePotion, "BLUE POTION SPRITESHEET FILE" }, {SpriteSheet.RedPotion, "RED POTION SPRITESHEET FILE" },
            {SpriteSheet.PowerBracelet, "POWER BRACELET SPRITESHEET FILE" }, {SpriteSheet.Raft, "RAFT SPRITESHEET FILE" },
            {SpriteSheet.Recorder, "RECORDER SPRITESHEET FILE" }, {SpriteSheet.BlueRing, "BLUE RING SPRITESHEET FILE" },
            {SpriteSheet.RedRing, "RED RING SPRITESHEET FILE" }, {SpriteSheet.Rupy, "RUPY SPRITESHEET FILE" },
            {SpriteSheet.FiveRupies, "FIVE RUPIES SPRITESHEET FILE" }, {SpriteSheet.Stepladder, "STEPLADDER SPRITESHEET FILE" },
            {SpriteSheet.Sword, "SWORD SPRITESHEET FILE" }, {SpriteSheet.WhiteSword, "WHITE SWORD SPRITESHEET FILE" },
            {SpriteSheet.Triforce, "TRIFORCE SPRITESHEET FILE" }, {SpriteSheet.Fire, "FIRE SPRITESHEET FILE" }
        };

        private static readonly Dictionary<SpriteSheet, Texture2D> Textures = new Dictionary<SpriteSheet, Texture2D>();

        public static void LoadContent(ContentManager content)
        {
            foreach (KeyValuePair<SpriteSheet, string> pair in FileNames)
            {
                Texture2D texture = content.Load<Texture2D>(pair.Value);
                Textures.Add(pair.Key, texture);
            }
        }

        public static Texture2D GetTexture(SpriteSheet sheetName)
        {
            return Textures.GetValueOrDefault(sheetName);
        }
    }

}
