using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionStuff
{
    interface ICollision
    {
        ICollider Collider1 { get; set; }
        ICollider Collider2 { get; set; }
    }
}
