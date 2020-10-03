namespace Sprint0
{
    class CommandQuit : ICommand
    {
        private Game1 myGame;

        public CommandQuit(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }

    }
}
