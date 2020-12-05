using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.ReverseTimeStuff
{
    class TimeState
    {
        public List<KeyValuePair<Type, Vector2>> Positions { get; set; }
        public Type playerState;

        public TimeState(Game1 game)
        {
            Positions = new List<KeyValuePair<Type, Vector2>>();
            playerState = game.player.State.GetType();

            // Save player:
            Positions.Add(new KeyValuePair<Type, Vector2>(game.player.GetType(), game.player.Position));

            // Save Enemies:
            foreach (IEnemy enemy in game.currentRoom.Enemies)
            {
                Positions.Add(new KeyValuePair<Type, Vector2>(enemy.GetType(), enemy.Position));
            }

            // Save NPCs:
            foreach (INPC npc in game.currentRoom.NPCs)
            {
                Positions.Add(new KeyValuePair<Type, Vector2>(npc.GetType(), npc.Position));
            }

            // Save Items:
            foreach (IItem item in game.currentRoom.Items)
            {
                Positions.Add(new KeyValuePair<Type, Vector2>(item.GetType(), item.Position));
            }

            // Save Hidden Items:
            foreach (IItem item in game.currentRoom.Items)
            {
                Positions.Add(new KeyValuePair<Type, Vector2>(item.GetType(), item.Position));
            }

            // Save Link's Active Items:
            foreach (IUsableItem item in game.player.ActiveItems)
            {
                Positions.Add(new KeyValuePair<Type, Vector2>(item.GetType(), item.Position));
            }
        }
    }
}
