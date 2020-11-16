using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.GameStateStuff
{
    public interface IGameState
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
