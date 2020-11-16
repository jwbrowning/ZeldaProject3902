using CrossPlatformDesktopProject.CommandStuff;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{
    class NormalKeyboardController : IController
    {
        private Game1 game;
        private Keys[] prevPressedKeys = new Keys[0];
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<Keys, ICommand> moveMappings;
        private int wait = 1;


        public NormalKeyboardController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            moveMappings = new Dictionary<Keys, ICommand>();
            moveMappings.Add(Keys.W, new CommandMoveUp(game));
            moveMappings.Add(Keys.A, new CommandMoveLeft(game));
            moveMappings.Add(Keys.S, new CommandMoveDown(game));
            moveMappings.Add(Keys.D, new CommandMoveRight(game));
            moveMappings.Add(Keys.Up, new CommandMoveUp(game));
            moveMappings.Add(Keys.Down, new CommandMoveDown(game));
            moveMappings.Add(Keys.Left, new CommandMoveLeft(game));
            moveMappings.Add(Keys.Right, new CommandMoveRight(game));
            /*RegisterCommand(Keys.D1, new CommandUseItem(game));
            RegisterCommand(Keys.D2, new CommandUseItem2(game));
            RegisterCommand(Keys.D3, new CommandUseItem3(game));*/
            RegisterCommand(Keys.B, new CommandUseItemB(game));
            RegisterCommand(Keys.N, new CommandUseItemN(game));
            RegisterCommand(Keys.E, new CommandDamage(game));
            RegisterCommand(Keys.C, new CommandShowColliders(game));
            RegisterCommand(Keys.V, new CommandRemoveColliders(game));
            /*Leftover code from Sprint 2
            RegisterCommand(Keys.T, new CommandSwitchBlockForward(game));
            RegisterCommand(Keys.Y, new CommandSwitchBlockBack(game));
            RegisterCommand(Keys.U, new CommandSwitchItemForward(game));
            RegisterCommand(Keys.I, new CommandSwitchItemBack(game));
            RegisterCommand(Keys.O, new CommandSwitchNPCForward(game));
            RegisterCommand(Keys.P, new CommandSwitchNPCBack(game));
            */
            RegisterCommand(Keys.Escape, new CommandPause(game));
            RegisterCommand(Keys.I, new CommandOpenInventory(game));
            RegisterCommand(Keys.R, new CommandReset(game));
            RegisterCommand(Keys.Q, new CommandQuit(game));
            RegisterCommand(Keys.M, new CommandMute());
        }


        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (wait <= 0)
            {
                if (prevPressedKeys.Contains(Keys.W) || prevPressedKeys.Contains(Keys.A) || prevPressedKeys.Contains(Keys.S) || prevPressedKeys.Contains(Keys.D))
                {
                    if (!pressedKeys.Contains(Keys.W) && !pressedKeys.Contains(Keys.A) && !pressedKeys.Contains(Keys.S) && !pressedKeys.Contains(Keys.D))
                    {
                        game.player.StopMoving();
                    }
                }
                if (prevPressedKeys.Contains(Keys.Up) || prevPressedKeys.Contains(Keys.Down) || prevPressedKeys.Contains(Keys.Left) || prevPressedKeys.Contains(Keys.Right))
                {
                    if (!pressedKeys.Contains(Keys.Up) && !pressedKeys.Contains(Keys.Down) && !pressedKeys.Contains(Keys.Left) && !pressedKeys.Contains(Keys.Right))
                    {
                        game.player.StopMoving();
                    }
                }

                bool doneMovement = false;
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key) && !prevPressedKeys.Contains(key))
                    {
                        controllerMappings[key].Execute();
                    }
                    if (moveMappings.ContainsKey(key) && !doneMovement)
                    {
                        moveMappings[key].Execute();
                        doneMovement = true;
                    }
                }
            }
            else
            {
                wait--;
                game.player.StopMoving();
            }

            prevPressedKeys = pressedKeys;
        }
    }
}
