namespace Sprint0
{
    class CommandSelect : ICommand
    {
        private Game1 myGame;
        public CommandSelect(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.hud.Select();
        }
    }
}