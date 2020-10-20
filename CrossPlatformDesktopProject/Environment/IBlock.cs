using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Environment
{
    public interface IBlock : IGameObject
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
