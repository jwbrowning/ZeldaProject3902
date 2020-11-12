using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class PausedGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public PausedGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new PausedKeyboardController(game)
            };
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
