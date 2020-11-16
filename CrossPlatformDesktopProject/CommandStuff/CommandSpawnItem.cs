using Microsoft.Xna.Framework;

namespace Sprint0
{
    class CommandSpawnItem : ICommand
    {
        private Game1 myGame;

        public CommandSpawnItem(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentRoom.Items.Add(new Clock(new Vector2(100, 0)));
        }
    }
}
