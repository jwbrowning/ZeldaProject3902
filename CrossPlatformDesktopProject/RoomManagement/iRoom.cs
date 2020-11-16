﻿using CrossPlatformDesktopProject.EnemySpriteClasses;
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
        List<IDoor> Doors { get; set; }
        List<IWall> Walls { get; set; }
        Vector2 Position { get; set; }
        Vector2 Destination { get; set; }
        iRoom nextRoom { get; set; }
        void ChangeRoom(string nextRoomName, string direction);

        void LoadRoom(string roomName);

        void RespawnEnemies();

        void UpdateBlocks();
        void UpdateNPCS();
        void UpdateEnemies();
        void UpdateItems();
        void UpdateDoors();

        void UpdateRooms();
        void UpdateWalls();

        void DrawBackground(SpriteBatch spriteBatch);
        void DrawBlocks(SpriteBatch spriteBatch);
        void DrawNPCS(SpriteBatch spriteBatch);
        void DrawEnemies(SpriteBatch spriteBatch);
        void DrawItems(SpriteBatch spriteBatch);
        void DrawDoors(SpriteBatch spriteBatch);
        void DrawWalls(SpriteBatch spriteBatch);

    }
}
