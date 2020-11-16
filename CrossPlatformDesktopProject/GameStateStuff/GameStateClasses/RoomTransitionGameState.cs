﻿using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class RoomTransitionGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public RoomTransitionGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>();
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
            game.currentRoom.UpdateRooms();
            game.currentRoom.nextRoom.UpdateRooms();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawBackground(spriteBatch);
            //game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.nextRoom.DrawBackground(spriteBatch);

        }
    }
}
