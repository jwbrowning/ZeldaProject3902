using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Sprint0
{
    class ControllerMouse : IController
    {
        private Game1 game;
        MouseState state;
        //TODO fix these magic numbers, how do i get the screen size?
        int windowWidth = 800;
        int windowHeight = 480;
        public ControllerMouse(Game1 game) {
            this.game = game;           
        }

        public void Update()
        {
            state = Mouse.GetState();
            bool leftPressed = ButtonState.Pressed == state.LeftButton ? true : false;
            if(leftPressed) {
                if(state.X>400) {
                    //load next stage
                    CommandSword swing = new CommandSword(game);
                    swing.Execute();
                } else {
                    //load prev stage
                }
            }
        }

        void IController.RegisterCommand(Keys key, ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
