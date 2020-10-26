using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.RoomManagement
{
    public interface iRoom
    {
        List<IEnemy> Enemies { get; set; }
        List<IBlock> Blocks { get; set; }
        List<IItem> Items { get; set; }
        List<INPC> NPCs { get; set; }

        void changeRoom(string nextRoomName);

        void loadRoom(string roomName);

        void respawnEnemies();


    }
}
