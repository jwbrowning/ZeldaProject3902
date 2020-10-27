namespace Sprint0
{
    class CommandMoveLeft : ICommand
	{
		private Game1 myGame;
		public CommandMoveLeft(Game1 game)
		{
			myGame = game;
		}

		public void Execute()
        {
            myGame.player.MoveLeft();
        }
	}
}
