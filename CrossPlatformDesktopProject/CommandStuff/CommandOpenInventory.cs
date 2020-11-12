namespace Sprint0
{
    class CommandOpenInventory : ICommand
    {
        private Game1 myGame;

        public CommandOpenInventory(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.OpenInventory();
        }
    }
}
