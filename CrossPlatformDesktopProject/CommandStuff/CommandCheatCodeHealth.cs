namespace Sprint0
{
    class CommandCheatCodeHealth : ICommand
    {
        private Game1 myGame;

        public CommandCheatCodeHealth(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.Health = 100000;
            myGame.player.TotalHealth = 100000;

        }
    }
}
