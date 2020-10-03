using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
	class ControllerKeyboard : IController
	{

		public ControllerKeyboard()
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
		}

		private Dictionary<Keys, ICommand> controllerMappings;


		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				if (controllerMappings.ContainsKey(key))
					controllerMappings[key].Execute();
			}
		}
	}
}
