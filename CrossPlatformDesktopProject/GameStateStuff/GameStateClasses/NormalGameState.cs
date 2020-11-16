using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.PlayerStuff;
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

        public NormalGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new NormalKeyboardController(game),
                new ControllerMouse(game)
            };
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
            game.player.Update();
            game.currentRoom.UpdateBlocks();
            game.currentRoom.UpdateNPCS();
            if(game.player.ItemCounts[PlayerStuff.ItemType.Clock] == 0) game.currentRoom.UpdateEnemies();
            game.currentRoom.UpdateItems();
            game.currentRoom.UpdateDoors();
            game.hud.Update();

            List<IGameObject> allGameObjects = game.currentRoom.Blocks.Concat<IGameObject>(game.currentRoom.Items).Concat(game.currentRoom.Doors).Concat(game.currentRoom.Enemies).Concat(game.currentRoom.NPCs).Concat(game.player.ActiveItems).Concat(new List<IGameObject>() { game.player, game.player.Sword }).ToList();
            CollisionDetection.DetectCollisions(allGameObjects);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawBackground(spriteBatch);
            game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.DrawNPCS(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.currentRoom.DrawDoors(spriteBatch);
            game.currentRoom.DrawEnemies(spriteBatch);
            game.player.Draw(spriteBatch, game.currentRoom.Position);
            game.hud.Draw(spriteBatch);
        }
    }
}
