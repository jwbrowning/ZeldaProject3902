using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class WinningGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public WinningGameState(Game1 game)
        {
            SoundFactory.Instance.musicDungeonLoop.Stop();
            this.game = game;
            controllers = new List<IController>
            {
                new GameOverKeyboardController(game)
            };
            SoundFactory.Instance.musicTriforce.Play();
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
