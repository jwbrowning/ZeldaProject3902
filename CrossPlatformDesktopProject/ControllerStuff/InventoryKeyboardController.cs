using CrossPlatformDesktopProject.CommandStuff;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{
    class InventoryKeyboardController : IController
    {
        private Game1 game;
        private Keys[] prevPressedKeys = new Keys[0];
        private Dictionary<Keys, ICommand> controllerMappings;
        private int wait = 1;

        public InventoryKeyboardController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand(Keys.W, new CommandSelectorMoveUp(game));
            RegisterCommand(Keys.A, new CommandSelectorMoveLeft(game));
            RegisterCommand(Keys.S, new CommandSelectorMoveDown(game));
            RegisterCommand(Keys.D, new CommandSelectorMoveRight(game));
            RegisterCommand(Keys.Up, new CommandSelectorMoveUp(game));
            RegisterCommand(Keys.Down, new CommandSelectorMoveDown(game));
            RegisterCommand(Keys.Left, new CommandSelectorMoveLeft(game));
            RegisterCommand(Keys.Right, new CommandSelectorMoveRight(game));
            RegisterCommand(Keys.Enter, new CommandSelect(game));
            RegisterCommand(Keys.Escape, new CommandCloseInventory(game));
            RegisterCommand(Keys.I, new CommandCloseInventory(game));
            RegisterCommand(Keys.R, new CommandReset(game));
            RegisterCommand(Keys.Q, new CommandQuit(game));
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
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key) && !prevPressedKeys.Contains(key))
                    {
                        controllerMappings[key].Execute();
                    }
                }
            }
            else
            {
                wait--;
            }

            prevPressedKeys = pressedKeys;
        }
    }
}
