namespace Sprint0
{
    class CommandUseItem3 : ICommand
    {
        private Game1 myGame;

        public CommandUseItem3(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.ThrowBoomerang();
        }
    }
}
