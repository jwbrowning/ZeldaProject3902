using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.RoomManagement
{
    public interface iRoom
    {
        List<IEnemy> Enemies { get; set; }
        List<IBlock> Blocks { get; set; }
        List<IItem> Items { get; set; }
        List<INPC> NPCs { get; set; }
        Vector2 Position { get; set; }

        void changeRoom(string nextRoomName);

        void loadRoom(string roomName);

        void respawnEnemies();

        void Update();

        void Draw(SpriteBatch spriteBatch);

    }
}
