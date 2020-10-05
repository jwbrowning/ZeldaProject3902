using CrossPlatformDesktopProject.PlayerStuff;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.UsableItems
{
    public interface IUsableItem : IGameObject
    {
        ISprite Sprite { get; set; }
    }
}
