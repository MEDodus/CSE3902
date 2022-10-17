using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Items.Classes;

namespace Zelda.Rooms.Parsers
{
    public class ItemParser : Parser
    {
        private HashSet<IItem> items;

        public ItemParser(string filename, HashSet<IItem> items) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\items.csv")
        {
            this.items = items;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            IItem item;
            Vector2 spawnPos = GetSpawnPosition(i, j) + new Vector2(5, 5);
            switch (identifier)
            {
                case "arrow":
                    item = new Arrow(spawnPos);
                    break;
                case "blue_candle":
                    item = new BlueCandle(spawnPos);
                    break;
                case "blue_potion":
                    item = new BluePotion(spawnPos);
                    break;
                case "blue_ring":
                    item = new BlueRing(spawnPos);
                    break;
                case "bomb":
                    item = new Bomb(spawnPos);
                    break;
                case "book_of_magic":
                    item = new BookOfMagic(spawnPos);
                    break;
                case "boomerang":
                    item = new Boomerang(spawnPos);
                    break;
                case "bow":
                    item = new Bow(spawnPos);
                    break;
                case "clock":
                    item = new Clock(spawnPos);
                    break;
                case "compass":
                    item = new Compass(spawnPos);
                    break;
                case "fire":
                    item = new Fire(spawnPos);
                    break;
                case "five_rupies":
                    item = new FiveRupies(spawnPos);
                    break;
                case "food":
                    item = new Food(spawnPos);
                    break;
                case "heart":
                    item = new Heart(spawnPos);
                    break;
                case "heart_container":
                    item = new HeartContainer(spawnPos);
                    break;
                case "key":
                    item = new Key(spawnPos);
                    break;
                case "letter":
                    item = new Letter(spawnPos);
                    break;
                case "magical_boomerang":
                    item = new MagicalBoomerang(spawnPos);
                    break;
                case "magical_key":
                    item = new MagicalKey(spawnPos);
                    break;
                case "magical_rod":
                    item = new MagicalRod(spawnPos);
                    break;
                case "magical_shield":
                    item = new MagicalShield(spawnPos);
                    break;
                case "map":
                    item = new Map(spawnPos);
                    break;
                case "power_bracelet":
                    item = new PowerBracelet(spawnPos);
                    break;
                case "raft":
                    item = new Raft(spawnPos);
                    break;
                case "recorder":
                    item = new Recorder(spawnPos);
                    break;
                case "red_candle":
                    item = new RedCandle(spawnPos);
                    break;
                case "red_potion":
                    item = new RedPotion(spawnPos);
                    break;
                case "red_ring":
                    item = new RedRing(spawnPos);
                    break;
                case "rupy":
                    item = new Rupy(spawnPos);
                    break;
                case "silver_arrow":
                    item = new SilverArrow(spawnPos);
                    break;
                case "stepladder":
                    item = new Stepladder(spawnPos);
                    break;
                case "sword":
                    item = new Sword(spawnPos);
                    break;
                case "triforce":
                    item = new Triforce(spawnPos);
                    break;
                case "white_sword":
                    item = new WhiteSword(spawnPos);
                    break;
                default:
                    throw new Exception("Item type not found: " + identifier);
            }
            items.Add(item);
        }
    }
}
