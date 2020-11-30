using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.ReverseTimeStuff
{
    class TimeManager
    {
        private Game1 game;
        private List<TimeState> timeStates;
        const int maxStackSize = 1000;
        
        public TimeManager(Game1 game)
        {
            this.game = game;
            timeStates = new List<TimeState>();
        }

        public void Update()
        {
            timeStates.Add(new TimeState(game));
            if(timeStates.Count > maxStackSize)
            {
                timeStates.RemoveAt(0);
            }
        }

        public void ReverseTime()
        {
            if (timeStates.Count == 0) return;

            TimeState state = timeStates[timeStates.Count - 1];
            timeStates.RemoveAt(timeStates.Count - 1);
            Dictionary<Type, int> typeCounts = new Dictionary<Type, int>();
            foreach (KeyValuePair<Type, Vector2> kvp in state.Positions)
            {
                if(typeof(IPlayer).IsAssignableFrom(kvp.Key))
                {
                    game.player.Position = kvp.Value;
                    game.player.State = (IPlayerState)Activator.CreateInstance(state.playerState, new object[] { game.player });
                }

                if (typeof(IEnemy).IsAssignableFrom(kvp.Key))
                {
                    int typeCount = typeCounts.ContainsKey(kvp.Key) ? typeCounts[kvp.Key] : 0;
                    if (typeCount != 0) typeCounts[kvp.Key]++;
                    else typeCounts.Add(kvp.Key, 1);
                    List<IEnemy> enemies = game.currentRoom.Enemies.FindAll((IEnemy e) => e.GetType() == kvp.Key).ToList();
                    IEnemy enemy = typeCount >= enemies.Count ? null : enemies[typeCount];
                    if (enemy != null) enemy.Position = kvp.Value;
                }

                if (typeof(INPC).IsAssignableFrom(kvp.Key))
                {
                    int typeCount = typeCounts.ContainsKey(kvp.Key) ? typeCounts[kvp.Key] : 0;
                    if (typeCount != 0) typeCounts[kvp.Key]++;
                    else typeCounts.Add(kvp.Key, 1);
                    List<INPC> npcs = game.currentRoom.NPCs.FindAll((INPC n) => n.GetType() == kvp.Key).ToList();
                    INPC npc = typeCount >= npcs.Count ? null : npcs[typeCount];
                    if (npc != null) npc.Position = kvp.Value;
                }

                if (typeof(IItem).IsAssignableFrom(kvp.Key))
                {
                    int typeCount = typeCounts.ContainsKey(kvp.Key) ? typeCounts[kvp.Key] : 0;
                    if (typeCount != 0) typeCounts[kvp.Key]++;
                    else typeCounts.Add(kvp.Key, 1);
                    List<IItem> items = game.currentRoom.Items.FindAll((IItem i) => i.GetType() == kvp.Key).ToList();
                    IItem item = typeCount >= items.Count ? null : items[typeCount];
                    if (item != null) item.Position = kvp.Value;
                }

                if (typeof(IItem).IsAssignableFrom(kvp.Key))
                {
                    int typeCount = typeCounts.ContainsKey(kvp.Key) ? typeCounts[kvp.Key] : 0;
                    if (typeCount != 0) typeCounts[kvp.Key]++;
                    else typeCounts.Add(kvp.Key, 1);
                    List<IItem> items = game.currentRoom.HiddenItems.FindAll((IItem i) => i.GetType() == kvp.Key).ToList();
                    IItem item = typeCount >= items.Count ? null : items[typeCount];
                    if (item != null) item.Position = kvp.Value;
                }

                if (typeof(IUsableItem).IsAssignableFrom(kvp.Key))
                {
                    int typeCount = typeCounts.ContainsKey(kvp.Key) ? typeCounts[kvp.Key] : 0;
                    if (typeCount != 0) typeCounts[kvp.Key]++;
                    else typeCounts.Add(kvp.Key, 1);
                    List<IUsableItem> items = game.player.ActiveItems.FindAll((IUsableItem i) => i.GetType() == kvp.Key).ToList();
                    IUsableItem item = typeCount >= items.Count ? null : items[typeCount];
                    if (item != null) item.Position = kvp.Value;
                }
            }
        }

        public void ClearTimeStates()
        {
            timeStates.Clear();
        }
    }
}
