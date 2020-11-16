﻿using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class NormalGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public NormalGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new NormalKeyboardController(game),
                new ControllerMouse(game)
            };
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
            game.player.Update();
            game.currentRoom.UpdateBlocks();
            game.currentRoom.UpdateNPCS();
            game.currentRoom.UpdateEnemies();
            game.currentRoom.UpdateItems();
            game.currentRoom.UpdateDoors();
            game.hud.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawBackground(spriteBatch);
            game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.DrawNPCS(spriteBatch);
            game.currentRoom.DrawEnemies(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.currentRoom.DrawDoors(spriteBatch);
            game.player.Draw(spriteBatch);
            game.hud.Draw(spriteBatch);
        }
    }
}
