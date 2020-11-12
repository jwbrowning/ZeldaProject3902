namespace Sprint0
{
    class CommandCloseInventory : ICommand
    {
        private Game1 myGame;

        public CommandCloseInventory(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.CloseInventory();
        }
    }
}
