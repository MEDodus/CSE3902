﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Commands;
using Zelda.Controllers;
using Zelda.Sprites;

namespace Zelda
{
    public static class Command
    {
        public static void Init(IController keyboard, Game1 game, Items items, Tiles tiles)
        {
            // TODO: add all keyboard keys as registered keys so no exeptions occur. as well as potentially a class to build all registered commands
            keyboard.RegisterCommand(Keys.D0, new Quit(game));
            keyboard.RegisterCommand(Keys.NumPad0, new Quit(game));

            // For player movement
            keyboard.RegisterCommand(Keys.W, new Up(game));
            keyboard.RegisterCommand(Keys.A, new Left(game));
            keyboard.RegisterCommand(Keys.S, new Down(game));
            keyboard.RegisterCommand(Keys.D, new Right(game));

            // For player attacks
            keyboard.RegisterCommand(Keys.Z, new Attack(game));
            keyboard.RegisterCommand(Keys.N, new Attack(game));

            // For usable items 
            keyboard.RegisterCommand(Keys.D1, new UseItem(game));
            keyboard.RegisterCommand(Keys.NumPad1, new UseItem(game));
            keyboard.RegisterCommand(Keys.D2, new UseItem(game));
            keyboard.RegisterCommand(Keys.NumPad2, new UseItem(game));
            keyboard.RegisterCommand(Keys.D3, new UseItem(game));
            keyboard.RegisterCommand(Keys.NumPad3, new UseItem(game));

            // For secondary items
            keyboard.RegisterCommand(Keys.X, new SecondaryItem(game));
            keyboard.RegisterCommand(Keys.M, new SecondaryItem(game));


            // The below keys only cycle between the previous or next sprite to be drawn for 
            // each object type. We could probably just have one command class instead of 6.


            // For enemies drawn to the screen
            keyboard.RegisterCommand(Keys.O, new CycleEnemyPrevious(game));
            keyboard.RegisterCommand(Keys.P, new CycleEnemyNext(game));

            // For quitting the game
            keyboard.RegisterCommand(Keys.Q, new Quit(game));

            InitTiles(keyboard, tiles);
            InitItems(keyboard, items);
            InitReset(keyboard, items, tiles);
        }

        public static void InitTiles(IController keyboard, Tiles tiles)
        {
            // For blocks drawn to the screen
            keyboard.RegisterCommand(Keys.T, new CycleBlockPrevious(tiles));
            keyboard.RegisterCommand(Keys.Y, new CycleBlockNext(tiles));
        }

        public static void InitItems(IController keyboard, Items items)
        {
            // For items drawn to the screen
            keyboard.RegisterCommand(Keys.U, new CycleItemPrevious(items));
            keyboard.RegisterCommand(Keys.I, new CycleItemNext(items));
        }

        public static void InitReset(IController keyboard, Items items, Tiles tiles)
        {
            // For reseting game state
            keyboard.RegisterCommand(Keys.R, new Reset(items, tiles));
        }
    }
}