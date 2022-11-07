using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;
using Zelda.Commands.Classes;
using Zelda.Controllers;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.Commands
{
    public class CommandBuilder
    {
        public CommandBuilder(KeyboardController keyboard, MouseController mouse, Game1 game)
        {
            // For quitting the game
            keyboard.RegisterCommand(Keys.Q, new Quit(game));

            // For pausing the game
            keyboard.RegisterCommand(Keys.P, new Pause(game));

            keyboard.RegisterCommand(Keys.M, new Mute());

            // For reseting game state
            //keyboard.RegisterCommand(Keys.R, new Reset(itemBuilder, blockBuilder, npcBuilder, game));

            // For player movement
            keyboard.RegisterCommand(Keys.W, new Up(game));
            keyboard.RegisterCommand(Keys.Up, new Up(game));
            keyboard.RegisterCommand(Keys.A, new Left(game));
            keyboard.RegisterCommand(Keys.Left, new Left(game));
            keyboard.RegisterCommand(Keys.S, new Down(game));
            keyboard.RegisterCommand(Keys.Down, new Down(game));
            keyboard.RegisterCommand(Keys.D, new Right(game));
            keyboard.RegisterCommand(Keys.Right, new Right(game));

            // For player attacks
            keyboard.RegisterCommand(Keys.Z, new Attack(game));
            keyboard.RegisterCommand(Keys.N, new Attack(game));

            // For usable items 
            keyboard.RegisterCommand(Keys.D1, new UseItem1(game));
            keyboard.RegisterCommand(Keys.NumPad1, new UseItem1(game));
            keyboard.RegisterCommand(Keys.D2, new UseItem2(game));
            keyboard.RegisterCommand(Keys.NumPad2, new UseItem2(game));
            keyboard.RegisterCommand(Keys.D3, new UseItem3(game));
            keyboard.RegisterCommand(Keys.NumPad3, new UseItem3(game));
            keyboard.RegisterCommand(Keys.D4, new UseItem4(game));
            keyboard.RegisterCommand(Keys.NumPad4, new UseItem4(game));
            keyboard.RegisterCommand(Keys.D5, new UseItem5(game));
            keyboard.RegisterCommand(Keys.NumPad5, new UseItem5(game));
            keyboard.RegisterCommand(Keys.D6, new UseItem6(game));
            keyboard.RegisterCommand(Keys.NumPad6, new UseItem6(game));
            keyboard.RegisterCommand(Keys.D7, new UseItem7(game));
            keyboard.RegisterCommand(Keys.NumPad7, new UseItem7(game));

            // For swapping rooms (sprint 3 only)
            mouse.RegisterLeftClickCommand(new CycleRoomPrevious(game.link));
            mouse.RegisterRightClickCommand(new CycleRoomNext(game.link));

            // For damaged state (sprint 2 only)
            //keyboard.RegisterCommand(Keys.E, new Hurt(game, link));

            // For secondary items
            //keyboard.RegisterCommand(Keys.X, new SecondaryItem(game));
            //keyboard.RegisterCommand(Keys.M, new SecondaryItem(game));
        }
    }
}
