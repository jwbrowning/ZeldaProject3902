using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Sprint0;
using Microsoft.Xna.Framework;
using System.Drawing.Printing;
using CrossPlatformDesktopProject.PlayerStuff;

namespace CrossPlatformDesktopProject.RoomManagement
{
    class Room1 : iRoom
    {
        private IPlayer player;
        public List<IEnemy> Enemies { get; set; }
        public List<IBlock> Blocks { get; set; }
        public List<IItem> Items { get; set; }

        public Room1(IPlayer link)
        {
            player = link;
            Enemies = new List<IEnemy>();
            Blocks = new List<IBlock>();
            Items = new List<IItem>();
        }
        public void changeRoom(iRoom nextroom)
        {
            throw new NotImplementedException();
        }

        public void loadRoom(String roomName)
        {
            XElement roomFile = XElement.Load("Content/Rooms/" + roomName + ".xml");

            IEnumerable <XElement> loadedEnvironmentObjects = from item in roomFile.Descendants("Item")
                      where (string)item.Element("ObjectType") == "Environment"
                      select item;
            foreach (XElement environmentObject in loadedEnvironmentObjects) {
                addEnvironmentObject(environmentObject);
            }
            IEnumerable<XElement> loadedEnemies = from item in roomFile.Descendants("Item")
                                                             where (string)item.Element("ObjectType") == "Enemy"
                                                             select item;
            foreach (XElement enemyObject in loadedEnemies)
            {
                addEnemy(enemyObject);
            }
            IEnumerable<XElement> loadedItems = from item in roomFile.Descendants("Item")
                                                  where (string)item.Element("ObjectType") == "Item"
                                                  select item;
            foreach (XElement itemObject in loadedItems)
            {
                addItem(itemObject);
            }
        }

        public void respawnEnemies()
        {
            throw new NotImplementedException();
        }

        void addEnvironmentObject(XElement environmentObject)
        {
            string[] location = ((string)environmentObject.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string) environmentObject.Element("ObjectName") == "BlockStandard")
            {
                Blocks.Add(new BlockStandard(new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueFish")
            {
                Blocks.Add(new Statue(new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueDragon")
            {
                //Blocks.Add(new Statue2(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "BlockMovable")
            {
                //TODO: Implement BlockMovable
                //Blocks.Add(new BlockMovable(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "Water")
            {
                //TODO Implement BlockWater
                //Blocks.Add(new BlockWater(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)environmentObject.Element("ObjectName") + "is not recognized.");
            }
        }

        void addEnemy(XElement enemy)
        {
            string[] location = ((string)enemy.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)enemy.Element("ObjectName") == "BlueKeese")
            {
                Enemies.Add(new BlueKeese(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "RedGoriya")
            {
                Enemies.Add(new BlueGoriya(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "Stalfos")
            {
                Enemies.Add(new Stalfos(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "BlackGel")
            {
                Enemies.Add(new BlackGel(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "BladeTrap")
            {
                Enemies.Add(new BladeTrap(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "WallMaster")
            {
                Enemies.Add(new WallMaster(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "Aquamentus")
            {
                Enemies.Add(new Aquamentus(player, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "OldMan")
            {
                //Enemies.Add(new OldMan(new Vector2(x * 16, y * 16)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)enemy.Element("ObjectName") + "is not recognized.");
            }
        }

        void addItem(XElement itemObject)
        {
            string[] location = ((string)itemObject.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)itemObject.Element("ObjectName") == "Boomerang")
            {
                Items.Add(new Boomerang(new Vector2(x * 16, y * 16)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Bow")
            {
                Items.Add(new Bow(new Vector2(x * 16, y * 16)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Map")
            {
                Items.Add(new Map(new Vector2(x * 16, y * 16)));
            }
            else if ((string)itemObject.Element("ObjectName") == "Compass")
            {
                Items.Add(new Compass(new Vector2(x * 16, y * 16)));
            }
            else if ((string)itemObject.Element("ObjectName") == "HeartContainer")
            {
                Items.Add(new HeartContainer(new Vector2(x * 16, y * 16)));
            }
            else if ((string)itemObject.Element("ObjectName") == "TriforcePiece")
            {
                Items.Add(new TriforcePiece(new Vector2(x * 16, y * 16)));
            }
            else
            {
                Console.WriteLine("ERROR: " + (string)itemObject.Element("ObjectName") + "is not recognized.");
            }
        }
        
        void addDoor(XElement doorObject)
        {
            if ((string)doorObject.Element("DoorPosition") == "Up")
            {

            }

        }
    }
}
