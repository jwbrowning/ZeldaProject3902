using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionStuff.ColliderStuff
{
    public interface ICollider
    {
        IGameObject GameObject { get; set; }
        Vector2 Size { get; set; }
        Vector2 Offset { get; set; }
    }
}
