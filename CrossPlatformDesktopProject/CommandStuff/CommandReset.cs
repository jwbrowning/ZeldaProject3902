using Sprint0;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandReset : ICommand
    {
        private Game1 myGame;
        public CommandReset(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Reinitialize();

        }
    }
}
