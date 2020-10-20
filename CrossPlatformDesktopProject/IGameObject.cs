using CrossPlatformDesktopProject.CollisionStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    public interface IGameObject : ICollidable
    {
        Vector2 Position { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
