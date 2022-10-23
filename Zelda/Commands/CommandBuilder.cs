using Microsoft.Xna.Framework.Input;
using Zelda.Commands.Classes;
using Zelda.Controllers;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.Commands
{
    public class CommandBuilder
    {
        public CommandBuilder(KeyboardController keyboard, MouseController mouse, Game1 game, ILink link, RoomBuilder roomBuilder)
        {
            // For quitting the game
            keyboard.RegisterCommand(Keys.Q, new Quit(game));

            // For reseting game state
            //keyboard.RegisterCommand(Keys.R, new Reset(itemBuilder, blockBuilder, npcBuilder, game));

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
            keyboard.RegisterCommand(Keys.D1, new UseItem1(game, link));
            keyboard.RegisterCommand(Keys.NumPad1, new UseItem1(game, link));
            keyboard.RegisterCommand(Keys.D2, new UseItem2(game, link));
            keyboard.RegisterCommand(Keys.NumPad2, new UseItem2(game, link));
            keyboard.RegisterCommand(Keys.D3, new UseItem3(game, link));
            keyboard.RegisterCommand(Keys.NumPad3, new UseItem3(game, link));
            keyboard.RegisterCommand(Keys.D4, new UseItem4(game, link));
            keyboard.RegisterCommand(Keys.NumPad4, new UseItem4(game, link));
            keyboard.RegisterCommand(Keys.D5, new UseItem5(game, link));
            keyboard.RegisterCommand(Keys.NumPad5, new UseItem5(game, link));
            keyboard.RegisterCommand(Keys.D6, new UseItem6(game, link));
            keyboard.RegisterCommand(Keys.NumPad6, new UseItem6(game, link));
            keyboard.RegisterCommand(Keys.D7, new UseItem7(game, link));
            keyboard.RegisterCommand(Keys.NumPad7, new UseItem7(game, link));

            // For swapping rooms (sprint 3 only)
            mouse.RegisterLeftClickCommand(new CycleRoomPrevious(roomBuilder));
            mouse.RegisterRightClickCommand(new CycleRoomNext(roomBuilder));

            // For damaged state (sprint 2 only)
            //keyboard.RegisterCommand(Keys.E, new Hurt(game, link));

            // For secondary items
            //keyboard.RegisterCommand(Keys.X, new SecondaryItem(game));
            //keyboard.RegisterCommand(Keys.M, new SecondaryItem(game));
        }
    }
}
