
using Sprint0;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandLoadGame : ICommand
    {
        private Game1 myGame;

        public CommandLoadGame(Game1 game)
        {
            myGame = game;
        }
        void ICommand.Execute()
        {
            myGame.LoadGame();
        }
    }
}
