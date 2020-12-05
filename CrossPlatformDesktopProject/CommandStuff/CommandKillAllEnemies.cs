using CrossPlatformDesktopProject.EnemySpriteClasses;

namespace Sprint0
{
    class CommandKillAllEnemies : ICommand
    {
        private Game1 myGame;

        public CommandKillAllEnemies(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.currentRoom.Enemies.Clear();
            foreach (IEnemy enemy in myGame.currentRoom.Enemies)
            {
                enemy.Die();
            }
        }
    }
}

