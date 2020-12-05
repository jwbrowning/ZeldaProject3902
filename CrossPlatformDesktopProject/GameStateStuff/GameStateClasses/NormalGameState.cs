using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.ReverseTimeStuff;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;
using System.Linq;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class NormalGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;
        private TimeManager timeManager;

        public NormalGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new NormalKeyboardController(game),
                new ControllerMouse(game)
            };
            timeManager = new TimeManager(game);
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
            if (game.reversingTime)
            {
                timeManager.ReverseTime();
                game.lightingManager.Update();
                game.player.ActiveItems.Clear();
            }
            else
            {
                game.player.Update();
                game.currentRoom.UpdateBlocks();
                game.currentRoom.UpdateNPCS();
                if (game.player.ItemCounts[PlayerStuff.ItemType.Clock] == 0) game.currentRoom.UpdateEnemies();
                game.currentRoom.UpdateItems();
                game.currentRoom.UpdateDoors();
                game.currentRoom.UpdateWalls();

                List<IGameObject> allGameObjects = game.currentRoom.Blocks.Concat<IGameObject>(game.currentRoom.Items).Concat(game.currentRoom.Doors).Concat(game.currentRoom.Walls).Concat(game.currentRoom.Enemies).Concat(game.currentRoom.NPCs).Concat(game.player.ActiveItems).Concat(new List<IGameObject>() { game.player, game.player.Sword }).ToList();
                CollisionDetection.DetectCollisions(allGameObjects);

                game.lightingManager.Update();
                game.hud.Update();

                timeManager.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawWalls(spriteBatch);
            game.currentRoom.DrawBackground(spriteBatch);
            game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.DrawNPCS(spriteBatch);
            game.currentRoom.DrawEnemies(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.currentRoom.DrawDoors(spriteBatch);
            game.currentRoom.DrawDialogue(spriteBatch);

            game.player.Draw(spriteBatch, game.currentRoom.Position);
            game.lightingManager.Draw(spriteBatch);
            game.hud.Draw(spriteBatch);
        }
    }
}
