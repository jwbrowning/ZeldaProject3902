namespace Sprint0
{
    class CommandSelectorMoveLeft : ICommand
    {
        private Game1 myGame;
        public CommandSelectorMoveLeft(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.hud.MoveSelectorLeft();
        }
    }
}