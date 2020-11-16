namespace Sprint0
{
    class CommandUseItemN : ICommand
    {
        private Game1 myGame;

        public CommandUseItemN(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.Attack();
        }
    }
}
