using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{
	class ControllerKeyboard : IController
	{
        private Game1 game;
        private Keys[] prevPressedKeys = new Keys[0];


        public ControllerKeyboard(Game1 game)
		{
            this.game = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand(Keys.D0, new CommandQuit(game));
            RegisterCommand(Keys.Up, new CommandMoveUp(game));
            RegisterCommand(Keys.Down, new CommandMoveDown(game));
            RegisterCommand(Keys.Left, new CommandMoveLeft(game));
            RegisterCommand(Keys.Right, new CommandMoveRight(game));
            RegisterCommand(Keys.W, new CommandMoveUp(game));
            RegisterCommand(Keys.S, new CommandMoveDown(game));
            RegisterCommand(Keys.A, new CommandMoveLeft(game));
            RegisterCommand(Keys.D, new CommandMoveRight(game));
            RegisterCommand(Keys.Z, new CommandSword(game));
            RegisterCommand(Keys.N, new CommandSword(game));
            RegisterCommand(Keys.E, new CommandDamage(game));
            RegisterCommand(Keys.T, new CommandSwitchBlock(game));
            RegisterCommand(Keys.Y, new CommandSwitchBlock(game));
            RegisterCommand(Keys.U, new CommandSwitchItem(game));
            RegisterCommand(Keys.I, new CommandSwitchItem(game));
            RegisterCommand(Keys.O, new CommandSwitchNPC(game));
            RegisterCommand(Keys.P, new CommandSwitchNPC(game));
        }

		private Dictionary<Keys, ICommand> controllerMappings;


		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if(prevPressedKeys.Contains(Keys.W) || prevPressedKeys.Contains(Keys.A) || prevPressedKeys.Contains(Keys.S) || prevPressedKeys.Contains(Keys.D))
            {
                if(!pressedKeys.Contains(Keys.W) && !pressedKeys.Contains(Keys.A) && !pressedKeys.Contains(Keys.S) && !pressedKeys.Contains(Keys.D))
                {
                    game.player.StopMoving();
                }
            }
            prevPressedKeys = pressedKeys;

            bool doneMovement = false;
			foreach (Keys key in pressedKeys)
			{
				if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                    if (key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D)
                    {
                        if(!doneMovement)
                        {
                            controllerMappings[key].Execute();
                        } 
                        else
                        {
                            doneMovement = true;
                        }
                    } 
                    else
                    {
                        controllerMappings[key].Execute();
                    }
                }
			}
		}
	}
}
