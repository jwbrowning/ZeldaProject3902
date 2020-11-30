using Sprint0;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandStopReversingTime : ICommand
    {
        private Game1 myGame;
        public CommandStopReversingTime(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.reversingTime = false;
        }
    }
}
