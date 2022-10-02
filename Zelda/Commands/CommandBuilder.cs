using Microsoft.Xna.Framework.Input;
using Zelda.Commands.Classes;
using Zelda.Blocks;
using Zelda.Controllers;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Link;

namespace Zelda.Commands
{
    public class CommandBuilder
    {
        public CommandBuilder(IController keyboard, Game1 game, ItemBuilder itemBuilder, BlockBuilder blockBuilder, NPCBuilder npcBuilder, ILink link)
        {
            // TODO: add all keyboard keys as registered keys so no exeptions occur. as well as potentially a class to build all registered commands

            // For quitting the game
            keyboard.RegisterCommand(Keys.Q, new Quit(game));

            // For reseting game state
            keyboard.RegisterCommand(Keys.R, new Reset(itemBuilder, blockBuilder, npcBuilder));

            // For player movement
            keyboard.RegisterCommand(Keys.W, new Up(game, link));
            keyboard.RegisterCommand(Keys.Up, new Up(game, link));
            keyboard.RegisterCommand(Keys.A, new Left(game, link));
            keyboard.RegisterCommand(Keys.Left, new Left(game, link));
            keyboard.RegisterCommand(Keys.S, new Down(game, link));
            keyboard.RegisterCommand(Keys.Down, new Down(game, link));
            keyboard.RegisterCommand(Keys.D, new Right(game, link));
            keyboard.RegisterCommand(Keys.Right, new Right(game, link));

            // For player attacks
            keyboard.RegisterCommand(Keys.Z, new Attack(game, link));
            keyboard.RegisterCommand(Keys.N, new Attack(game, link));

            // For usable items 
            keyboard.RegisterCommand(Keys.D1, new UseItem(game, link));
            keyboard.RegisterCommand(Keys.NumPad1, new UseItem(game, link));
            keyboard.RegisterCommand(Keys.D2, new UseItem(game, link));
            keyboard.RegisterCommand(Keys.NumPad2, new UseItem(game, link));
            keyboard.RegisterCommand(Keys.D3, new UseItem(game, link));
            keyboard.RegisterCommand(Keys.NumPad3, new UseItem(game, link));

            // For secondary items
            //keyboard.RegisterCommand(Keys.X, new SecondaryItem(game));
            //keyboard.RegisterCommand(Keys.M, new SecondaryItem(game));

            // Swapping enemies
            keyboard.RegisterCommand(Keys.O, new CycleNPCPrevious(npcBuilder));
            keyboard.RegisterCommand(Keys.P, new CycleNPCNext(npcBuilder));

            // Swapping items
            keyboard.RegisterCommand(Keys.U, new CycleItemPrevious(itemBuilder));
            keyboard.RegisterCommand(Keys.I, new CycleItemNext(itemBuilder));

            // Swapping blocks
            keyboard.RegisterCommand(Keys.T, new CycleBlockPrevious(blockBuilder));
            keyboard.RegisterCommand(Keys.Y, new CycleBlockNext(blockBuilder));
        }
    }
}
