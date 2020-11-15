using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CrossPlatformDesktopProject.RoomManagement
{
    class Room1 : iRoom
    {
        private Game1 mygame;
        public List<IEnemy> Enemies { get; set; }
        public List<IBlock> Blocks { get; set; }
        public List<IItem> Items { get; set; }
        public List<INPC> NPCs { get; set; }
        public Vector2 Position { get; set; }
        private Texture2D floorBaseWithWalls;
        private Vector2 size = new Vector2(1024, 704);

        /*XSCALE and YSCALE convert the object coordinates from tiles to pixels. 
		In the original game each tile is 16 pixels wide, but upscaled by 4 for 
		visibility so each tile is actually 64 pixels*/
        const int XSCALE = 64;
        const int YSCALE = 64;
        /*Offsets are used to shift the tile grid down and to the right
		to account for the border walls and HUD. Even though the border wall
		is only 64 pixels wide, 32 pixels are added to account for the sprite's
		Draw methods using the center of the sprite, not the top left corner*/
        int XOFFSET = 98;
        int YOFFSET = 98;
        public Room1(Game1 game, Vector2 position, Texture2D floorBaseWithWalls)
        {
            mygame = game;
            Enemies = new List<IEnemy>();
            Blocks = new List<IBlock>();
            Items = new List<IItem>();
            NPCs = new List<INPC>();
            Position = position;
            this.floorBaseWithWalls = floorBaseWithWalls;
            XOFFSET = 98 + (int)(Position.X - size.X / 2f);
            YOFFSET = 98 + (int)(Position.Y - size.Y / 2f);
        }

        //unused, to be used to manage transitions/animations when changing rooms
        public void ChangeRoom(string nextRoomName)
        {
            throw new NotImplementedException();
        }

        public void LoadRoom(String roomName)
        {
            Enemies.Clear();
            Blocks.Clear();
            Items.Clear();
            NPCs.Clear();

            //moves Link to the bottom of the map to avoid issues where blocks would spawn on top of him
            mygame.player.Position = new Vector2(6 * XSCALE + XOFFSET, 7 * YSCALE + YOFFSET);

            XElement roomFile = XElement.Load("../../../../Content/Rooms/" + roomName + ".xml");

            IEnumerable<XElement> loadedEnvironmentObjects = from item in roomFile.Descendants("Item")
                                                             where (string)item.Element("ObjectType") == "Environment"
                                                             select item;
            foreach (XElement environmentObject in loadedEnvironmentObjects)
            {
                AddEnvironmentObject(environmentObject);
            }
            IEnumerable<XElement> loadedEnemies = from item in roomFile.Descendants("Item")
                                                  where (string)item.Element("ObjectType") == "Enemy"
                                                  select item;
            foreach (XElement enemyObject in loadedEnemies)
            {
                AddEnemy(enemyObject);
            }
            IEnumerable<XElement> loadedItems = from item in roomFile.Descendants("Item")
                                                where (string)item.Element("ObjectType") == "Item"
                                                select item;
            foreach (XElement itemObject in loadedItems)
            {
                AddItem(itemObject);
            }
            IEnumerable<XElement> loadedNPCs = from item in roomFile.Descendants("Item")
                                               where (string)item.Element("ObjectType") == "NPC"
                                               select item;
            foreach (XElement NPCObject in loadedNPCs)
            {
                AddNPC(NPCObject);
            }
        }

        public void RespawnEnemies()
        {
            throw new NotImplementedException();
        }

        void AddEnvironmentObject(XElement environmentObject)
        {
            string[] location = ((string)environmentObject.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)environmentObject.Element("ObjectName") == "BlockStandard")
            {
                Blocks.Add(new BlockStandard(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueFish")
            {
                Blocks.Add(new Statue(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueDragon")
            {
                Blocks.Add(new StatueDragon(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "Stairs")
            {
                Blocks.Add(new Stairs(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "BlockMovable")
            {
                //TODO: Implement BlockMovable
                //Blocks.Add(new BlockMovable(Game1.environment, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "Water")
            {
                Blocks.Add(new BlockWater(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)environmentObject.Element("ObjectName") + " is not a recognized block.");
            }
        }

        void AddEnemy(XElement enemy)
        {
            string[] location = ((string)enemy.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)enemy.Element("ObjectName") == "BlueKeese")
            {
                Enemies.Add(new BlueKeese(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "RedGoriya")
            {
                Enemies.Add(new BlueGoriya(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "Stalfos")
            {
                Enemies.Add(new Stalfos(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "BlackGel")
            {
                Enemies.Add(new BlackGel(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "BladeTrap")
            {
                Enemies.Add(new BladeTrap(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "WallMaster")
            {
                Enemies.Add(new WallMaster(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "Aquamentus")
            {
                Enemies.Add(new Aquamentus(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "Flame")
            {
                Enemies.Add(new Flame(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)enemy.Element("ObjectName") == "Wallmaster")
            {
                Enemies.Add(new WallMaster(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)enemy.Element("ObjectName") + " is not a recognized enemy.");
            }
        }

        void AddNPC(XElement NPC)
        {
            string[] location = ((string)NPC.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)NPC.Element("ObjectName") == "OldMan")
            {
                NPCs.Add(new OldMan(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)NPC.Element("ObjectName") + " is not a recognized NPC.");
            }
        }

        void AddItem(XElement itemObject)
        {
            string[] location = ((string)itemObject.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)itemObject.Element("ObjectName") == "Boomerang")
            {
                Items.Add(new Boomerang(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Bow")
            {
                Items.Add(new Bow(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Key")
            {
                Items.Add(new Key(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Map")
            {
                Items.Add(new Map(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Compass")
            {
                Items.Add(new Compass(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "HeartContainer")
            {
                Items.Add(new HeartContainer(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "TriforcePiece")
            {
                Items.Add(new TriforcePiece(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Arrows")
            {
                Items.Add(new Arrow(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Bomb")
            {
                Items.Add(new Bomb(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Clock")
            {
                Items.Add(new Clock(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Fairy")
            {
                Items.Add(new Fairy(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Heart")
            {
                Items.Add(new Heart(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Rupee")
            {
                Items.Add(new Rupee(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)itemObject.Element("ObjectName") + " is not a recognized item.");
            }
        }

        void AddDoor(XElement doorObject)
        {
            if ((string)doorObject.Element("DoorPosition") == "Up")
            {

            }

        }

        public void UpdateNPCS()
        {
            for (int i = 0; i < NPCs.Count; i++)
            {
                NPCs[i].Update();
            }
        }

        public void UpdateEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update();
            }
        }

        public void UpdateItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Update();
            }
        }

        public void UpdateBlocks()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Update();
            }
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(floorBaseWithWalls, new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y), Color.White);
            spriteBatch.End();
        }

        public void DrawBlocks(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch);
            }
        }

        public void DrawNPCS(SpriteBatch spriteBatch)
        {
            foreach (INPC npc in NPCs)
            {
                npc.Draw(spriteBatch);
            }
        }

        public void DrawEnemies(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void DrawItems(SpriteBatch spriteBatch)
        {
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
