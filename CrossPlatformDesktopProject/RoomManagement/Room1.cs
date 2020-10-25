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
                addEnemy(enemyObject, Blocks);
            }
        }

        public void respawnEnemies()
        {
            throw new NotImplementedException();
        }

        void addEnvironmentObject(XElement environmentObject, List<IBlock> environmentObjectList)
        {
            string[] location = ((string)environmentObject.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string) environmentObject.Element("ObjectName") == "BlockStandard")
            {
                Blocks.Add(new BlockStandard(Game1.environment, new Vector2(x*16, y*16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "StatueFish")
            {
                Blocks.Add(new Statue(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)environmentObject.Element("ObjectName") == "BlockMovable")
            {
                //TODO: Implement BlockMovable
                //Blocks.Add(new BlockMovable(Game1.environment, new Vector2(x * 16, y * 16)));
            }
        }

        void addEnemy(XElement enemy, List<IEnemy> enemyList)
        {
            string[] location = ((string)enemy.Element("Location")).Split(' ');
            int x = int.Parse(location[0]);
            int y = int.Parse(location[1]);

            if ((string)enemy.Element("ObjectName") == "BlueKeese")
            {
                //Blocks.Add(new BlueKeese(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "RedGoriya")
            {
                //Blocks.Add(new RedGoriya(Game1.environment, new Vector2(x * 16, y * 16)));
            }
            else if ((string)enemy.Element("ObjectName") == "BlockMovable")
            {
                //TODO: Implement BlockMovable
                //Blocks.Add(new BlockMovable(Game1.environment, new Vector2(x * 16, y * 16)));
            }
        }
    }
}
