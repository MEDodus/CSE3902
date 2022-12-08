using Microsoft.Xna.Framework.Input;
using Zelda.Commands.Classes;
using Zelda.Controllers;

namespace Zelda.Commands
{
    public class CommandBuilder
    {
        public CommandBuilder(KeyboardController keyboard, MouseController mouse, Game1 game)
        {
            // Game controls
            keyboard.RegisterCommand(Keys.Q, new Quit(game));
            keyboard.RegisterCommand(Keys.P, new Pause(game));
            keyboard.RegisterCommand(Keys.R, new Reset(game));
            keyboard.RegisterCommand(Keys.O, new Mute(game));

            // General input (WASD/arrow keys/mouse), behavior depends on game state
            keyboard.RegisterCommand(Keys.W, new Up(game));
            keyboard.RegisterCommand(Keys.Up, new Up(game));
            keyboard.RegisterCommand(Keys.A, new Left(game));
            keyboard.RegisterCommand(Keys.Left, new Left(game));
            keyboard.RegisterCommand(Keys.S, new Down(game));
            keyboard.RegisterCommand(Keys.Down, new Down(game));
            keyboard.RegisterCommand(Keys.D, new Right(game));
            keyboard.RegisterCommand(Keys.Right, new Right(game));
            mouse.RegisterLeftClickCommand(new LeftClick(game));
            mouse.RegisterRightClickCommand(new RightClick(game));

            // For player attacks
            keyboard.RegisterCommand(Keys.X, new Attack(game, 1));
            keyboard.RegisterCommand(Keys.M, new Attack(game, 2));
            keyboard.RegisterCommand(Keys.Z, new AttackSecondary(game, 1));
            keyboard.RegisterCommand(Keys.N, new AttackSecondary(game, 2));
            keyboard.RegisterCommand(Keys.CapsLock, new MarioKartAttack(game, 1));
            keyboard.RegisterCommand(Keys.RightAlt, new MarioKartAttack(game, 2));

            // Cheats
            keyboard.RegisterCommand(Keys.H, new HealthCheat(game));
            keyboard.RegisterCommand(Keys.D0, new ItemCheat(game, 0));
            keyboard.RegisterCommand(Keys.D1, new ItemCheat(game, 1));
            keyboard.RegisterCommand(Keys.D2, new ItemCheat(game, 2));
            keyboard.RegisterCommand(Keys.D3, new ItemCheat(game, 3));
            keyboard.RegisterCommand(Keys.D4, new ItemCheat(game, 4));
            keyboard.RegisterCommand(Keys.D5, new ItemCheat(game, 5));
            keyboard.RegisterCommand(Keys.D6, new ItemCheat(game, 6));
            keyboard.RegisterCommand(Keys.D7, new ItemCheat(game, 7));
            keyboard.RegisterCommand(Keys.D8, new ItemCheat(game, 8));
            keyboard.RegisterCommand(Keys.D9, new ItemCheat(game, 9));

        }
    }
}
