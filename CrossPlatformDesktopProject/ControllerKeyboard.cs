using CrossPlatformDesktopProject.CommandStuff;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{
	class ControllerKeyboard : IController
	{
        private Game1 game;
        private Keys[] prevPressedKeys = new Keys[0];
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<Keys, ICommand> moveMappings;


        public ControllerKeyboard(Game1 game)
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
            RegisterCommand(Keys.D0, new CommandQuit(game));
            RegisterCommand(Keys.D1, new CommandUseItem(game));
            RegisterCommand(Keys.D2, new CommandUseItem(game));
            RegisterCommand(Keys.D3, new CommandUseItem(game));
            RegisterCommand(Keys.Z, new CommandSword(game));
            RegisterCommand(Keys.N, new CommandSword(game));
            RegisterCommand(Keys.E, new CommandDamage(game));
            RegisterCommand(Keys.T, new CommandSwitchBlock(game));
            RegisterCommand(Keys.Y, new CommandSwitchBlock(game));
            RegisterCommand(Keys.U, new CommandSwitchItem(game));
            RegisterCommand(Keys.I, new CommandSwitchItem(game));
            RegisterCommand(Keys.O, new CommandSwitchNPC(game));
            RegisterCommand(Keys.P, new CommandSwitchNPC(game));
            RegisterCommand(Keys.R, new CommandReset(game));
        }


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
                }
                if (moveMappings.ContainsKey(key) && !doneMovement)
                {
                    moveMappings[key].Execute();
                    doneMovement = true;
                }
			}
		}
	}
}
