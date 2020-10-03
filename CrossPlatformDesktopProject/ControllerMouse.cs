using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint0
{
    class ControllerMouse : IController
    {

        MouseState state;
        //TODO fix these magic numbers, how do i get the screen size?
        int windowWidth = 800;
        int windowHeight = 480;
        public bool Button0Pressed()
        {
            if (state.RightButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool Button1Pressed()
        {
            if (state.X < windowWidth / 2 && state.Y < windowHeight / 2)
            {
                if (state.LeftButton == ButtonState.Pressed)
                    return true;
            }
            return false;
        }

        public bool Button2Pressed()
        {
            if (state.X >= windowWidth / 2 && state.Y < windowHeight / 2)
            {
                if (state.LeftButton == ButtonState.Pressed)
                    return true;
            }
            return false;
        }

        public bool Button3Pressed()
        {
            if (state.X < windowWidth / 2 && state.Y >= windowHeight / 2)
            {
                if (state.LeftButton == ButtonState.Pressed)
                    return true;
            }
            return false;
        }

        public bool Button4Pressed()
        {
            if (state.X >= windowWidth / 2 && state.Y >= windowHeight / 2)
            {
                if (state.LeftButton == ButtonState.Pressed)
                    return true;
            }
            return false;
        }

        public void Update()
        {
            state = Mouse.GetState();
        }

        void IController.RegisterCommand(Keys key, ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
