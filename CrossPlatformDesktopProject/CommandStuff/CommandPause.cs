namespace Sprint0
{
    class CommandPause : ICommand
    {
        private Game1 myGame;

        public CommandPause(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Pause();
        }
    }
}

