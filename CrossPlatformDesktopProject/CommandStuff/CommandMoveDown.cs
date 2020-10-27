namespace Sprint0
{
    class CommandMoveDown : ICommand
		{
			private Game1 myGame;
			public CommandMoveDown(Game1 game)
			{
				myGame = game;
			}

			public void Execute()
			{
				myGame.player.MoveDown();
			}
		}
}
