using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.RoomManagement;
using CrossPlatformDesktopProject.SoundManagement;
using Sprint0;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Items
{
    class LootManagement
    {
        const int heartChance = 15;
        const int rupeeChance = 15;
        const int clockChance = 5;
        const int bombChance = 10;

        int heartWindow = heartChance;
        int rupeeWindow = heartChance + rupeeChance;
        int clockWindow = rupeeChance + clockChance;
        int bombWindow = clockChance + bombChance;

        public static List<string> lootAlreadyDropped = new List<string>();

        private static LootManagement instance = new LootManagement();
        public static LootManagement Instance
        {
            get
            {
                return instance;
            }
        }

        public LootManagement()
        {

        }

        public static void ResetLoot()
        {
            lootAlreadyDropped.Clear();
        }

        void rollRandomLoot(iRoom room, IEnemy enemy)
        {
            Random rand = new Random();
            //Chooses a random number between 1 and 100, and compares it to a table of loot.
            //Drops the random item at the same position of the enemy
            int lootRoll = rand.Next(1, 101);

            if (lootRoll <= heartWindow)
            {
                room.Items.Add(new Heart(enemy.Position));
            }
            else if (lootRoll <= rupeeWindow)
            {
                room.Items.Add(new Rupee(enemy.Position));
            }
            else if (lootRoll <= clockWindow)
            {
                room.Items.Add(new Clock(enemy.Position));
            }
            else if (lootRoll <= bombWindow)
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
                    if (!lootAlreadyDropped.Contains(((Room1)room).CurrentRoom))
                    {
                        room.Items.Add(new Key(enemy.Position));
                    }
                }
            }
        }

        void revealHiddenLoot(iRoom room)
        {
            if (room.Enemies.FindAll(enemy => !(enemy is EnemyBoomerang || enemy is Fireball)).Count == 1)
            //triggers if this enemy that died is the last enemy in the room
            {
                if (room.HiddenItems.Count > 0)
                {
                    if (!lootAlreadyDropped.Contains(((Room1)room).CurrentRoom))
                    {
                        SoundFactory.Instance.sfxHiddenKeyAppears.Play();
                        room.Items.AddRange(room.HiddenItems);
                    }
                }
            }
        }

        public void enemyDeathLootCheck(iRoom room, IEnemy enemy)
        {
            rollRandomLoot(room, enemy);
            dropSpecificLoot(room, enemy);
            revealHiddenLoot(room);

        }
    }
}
