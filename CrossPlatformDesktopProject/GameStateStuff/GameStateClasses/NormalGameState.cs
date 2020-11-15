﻿using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;

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
            game.hud.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawBackground(spriteBatch);
            game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.DrawNPCS(spriteBatch);
            game.currentRoom.DrawEnemies(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.player.Draw(spriteBatch);
            game.hud.Draw(spriteBatch);
        }
    }
}
