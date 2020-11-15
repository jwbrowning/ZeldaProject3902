namespace Sprint0
{
    class CommandMoveUp : ICommand
    {
        private Game1 myGame;
        public CommandMoveUp(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.MoveUp();
        }
    }
}
