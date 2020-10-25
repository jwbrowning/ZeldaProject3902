using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.RoomManagement
{
    interface iRoom
    {
        List<IEnemy> Enemies { get; set; }
        List<IBlock> Blocks { get; set; }
        List<IItem> Items { get; set; }

        void changeRoom(iRoom nextroom);

        void loadRoom(string roomName);

        void respawnEnemies();


    }
}
