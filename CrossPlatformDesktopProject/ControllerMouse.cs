using CrossPlatformDesktopProject.RoomManagement;
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
        bool leftPressedLast = false;
        bool rightPressedLast = false;
        public ControllerMouse(Game1 game) {
            this.game = game;           
        }

        public void Update()
        {
            state = Mouse.GetState();
            bool leftPressed = ButtonState.Pressed == state.LeftButton ? true : false;
            bool rightPressed = ButtonState.Pressed == state.RightButton ? true : false;
           
            if (rightPressed && !rightPressedLast)
            {
                if (game.roomIndex + 1 < game.rooms.Length)
                {
                    game.roomIndex++;
                    game.currentRoom.loadRoom(game.rooms[game.roomIndex]);
                }
                else
                {
                    game.roomIndex = 0;
                    game.currentRoom.loadRoom(game.rooms[game.roomIndex]);
                }
            }
            if (leftPressed && !leftPressedLast)
            {
                if (game.roomIndex - 1 >= 0)
                {
                    game.roomIndex--;
                    game.currentRoom.loadRoom(game.rooms[game.roomIndex]);
                }
                else
                {
                    game.roomIndex = game.rooms.Length - 1;
                    game.currentRoom.loadRoom(game.rooms[game.roomIndex]);
                }
            }
            leftPressedLast = leftPressed;
            rightPressedLast = rightPressed;
        }

        void IController.RegisterCommand(Keys key, ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
