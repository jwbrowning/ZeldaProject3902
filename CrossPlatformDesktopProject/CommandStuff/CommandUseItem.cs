namespace Sprint0
{
    class CommandUseItem : ICommand
    {
        private Game1 myGame;

        public CommandUseItem(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.ShootArrow();
        }
    }
}
