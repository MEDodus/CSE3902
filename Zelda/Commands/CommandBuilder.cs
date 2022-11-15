﻿using Microsoft.Xna.Framework.Input;
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
            keyboard.RegisterCommand(Keys.O, new Mute());

            // Player movement
            keyboard.RegisterCommand(Keys.W, new Up(game));
            keyboard.RegisterCommand(Keys.Up, new Up(game));
            keyboard.RegisterCommand(Keys.A, new Left(game));
            keyboard.RegisterCommand(Keys.Left, new Left(game));
            keyboard.RegisterCommand(Keys.S, new Down(game));
            keyboard.RegisterCommand(Keys.Down, new Down(game));
            keyboard.RegisterCommand(Keys.D, new Right(game));
            keyboard.RegisterCommand(Keys.Right, new Right(game));

            // For player attacks
            keyboard.RegisterCommand(Keys.X, new Attack(game));
            keyboard.RegisterCommand(Keys.M, new Attack(game));
            keyboard.RegisterCommand(Keys.Z, new AttackSecondary(game));
            keyboard.RegisterCommand(Keys.N, new AttackSecondary(game));

            // Cheats
            keyboard.RegisterCommand(Keys.H, new HealthCheat(game));
            mouse.RegisterLeftClickCommand(new CycleRoomPrevious(game));
            mouse.RegisterRightClickCommand(new CycleRoomNext(game));

        }
    }
}
