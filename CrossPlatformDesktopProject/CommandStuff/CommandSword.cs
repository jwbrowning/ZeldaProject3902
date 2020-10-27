namespace Sprint0
{
    class CommandSword : ICommand
    {
        private Game1 myGame;

        public CommandSword (Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.Attack();
        }
    }
}
