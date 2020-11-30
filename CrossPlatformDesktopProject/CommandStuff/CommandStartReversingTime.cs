using Sprint0;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandStartReversingTime : ICommand
    {
        private Game1 myGame;
        public CommandStartReversingTime(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.reversingTime = true;
        }
    }
}
