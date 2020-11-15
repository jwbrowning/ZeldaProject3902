namespace Sprint0
{
    class CommandUnpause : ICommand
    {
        private Game1 myGame;

        public CommandUnpause(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Unpause();
        }
    }
}

