namespace Sprint0
{
    class CommandMoveRight : ICommand
	{
		private Game1 myGame;
		public CommandMoveRight(Game1 game)
		{
			myGame = game;
		}

		public void Execute()
        {
            myGame.player.MoveRight();
        }
	}
}
