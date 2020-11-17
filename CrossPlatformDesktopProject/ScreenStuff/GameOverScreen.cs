using CrossPlatformDesktopProject.ScreenStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class GameOverScreen : IScreen
    {
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private Game1 game;

        public GameOverScreen(Game1 game, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(game.font, "GAME OVER", new Vector2(480, 440), Color.White);
            spriteBatch.DrawString(game.font, "R or Enter to Reset", new Vector2(480, 480), Color.White);
            spriteBatch.End();
        }
    }
}
