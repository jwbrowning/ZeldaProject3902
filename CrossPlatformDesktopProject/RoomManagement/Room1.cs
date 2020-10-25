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

namespace CrossPlatformDesktopProject.RoomManagement
{
    class Room1 : iRoom
    {
        public List<IEnemy> Enemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IBlock> Blocks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IItem> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
                addEnvironmentObject(environmentObject, Blocks);
            }
            IEnumerable<XElement> loadedEnemies = from item in roomFile.Descendants("Item")
                                                             where (string)item.Element("ObjectType") == "Enemy"
                                                             select item;
            foreach (XElement enemyObject in loadedEnemies)
            {
                addEnemy(enemyObject, Enemies);
            }
            IEnumerable<XElement> loadedItems = from item in roomFile.Descendants("Item")
                                                  where (string)item.Element("ObjectType") == "Item"
                                                  select item;
            foreach (XElement itemObject in loadedItems)
            {
                addItem(itemObject, Items);
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
                Blocks.Add(new BlockStandard(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueFish")
            {
                Blocks.Add(new Statue(Game1.environment, new Vector2(x * 16, y * 16)));
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
                Enemies.Add(new BlueKeese(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "RedGoriya")
            {
                Enemies.Add(new RedGoriya(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "Stalfos")
            {
                Enemies.Add(new Stalfos(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "BlackGel")
            {
                Enemies.Add(new BlackGel(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "BladeTrap")
            {
                Enemies.Add(new BladeTrap(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "WallMaster")
            {
                Enemies.Add(new WallMaster(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "Aquamentus")
            {
                Enemies.Add(new Aquamentus(Game1.environment, new Vector2(x * 16, y * 16)));
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
