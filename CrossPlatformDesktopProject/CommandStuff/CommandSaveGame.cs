
using Sprint0;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandSaveGame : ICommand
    {
        private Game1 myGame;

        public CommandSaveGame(Game1 game)
        {
            myGame = game;
        }
        void ICommand.Execute()
        {
            myGame.SaveGame();
        }
    }
}
