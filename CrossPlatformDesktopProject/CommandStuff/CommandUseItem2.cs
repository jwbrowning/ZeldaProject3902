namespace Sprint0
{
    class CommandUseItem2 : ICommand
    {
        private Game1 myGame;

        public CommandUseItem2(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.UseBomb();
        }
    }
}
