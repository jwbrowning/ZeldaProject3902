namespace Sprint0
{
    class CommandShowColliders : ICommand
    {
        private Game1 myGame;

        public CommandShowColliders(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.showCollisions = true;
        }
    }
}
