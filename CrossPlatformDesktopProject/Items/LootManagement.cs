using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.RoomManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Items
{
    class LootManagement
    {
        const int heartChance = 10;
        const int rupeeChance = heartChance + 10;
        const int clockChance = rupeeChance + 5;
        const int bombChance = clockChance + 5;

        void rollRandomLoot(iRoom room, IEnemy enemy)
        {
            Random rand = new Random();
            //Chooses a random number between 1 and 100, and compares it to a table of loot.
            //Drops the random item at the same position of the enemy
            int lootRoll =  rand.Next(1,101);

            if (lootRoll <= heartChance)
            {
                room.Items.Add(new Heart(enemy.Position));
            }
            else if (lootRoll <= rupeeChance)
            {
                room.Items.Add(new Rupee(enemy.Position));
            }
            else if (lootRoll <= clockChance)
            {
                room.Items.Add(new Clock(enemy.Position));
            }
            else if (lootRoll <= bombChance)
            {
                room.Items.Add(new Bomb(enemy.Position));
            }
            else
            {
                //drop nothing
            }
        }

        void dropSpecificLoot(iRoom room, IEnemy enemy)
        {
            if (enemy.carriedLoot != "")
            {
                if (enemy.carriedLoot == "Key")
                {
                    room.Items.Add(new Key(enemy.Position));
                }
            }
        }

        void revealHiddenLoot(iRoom room)
        {
            if(room.Enemies.Count <= 0)
            {
                room.Items.Concat(room.HiddenItems);
            }
        }

        void enemyDeathLootCheck(iRoom room, IEnemy enemy)
        {
            rollRandomLoot(room, enemy);
            dropSpecificLoot(room, enemy);
            revealHiddenLoot(room);

        }
    }
}
