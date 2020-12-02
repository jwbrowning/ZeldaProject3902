namespace Sprint0
{
    class CommandEnablePartyLights : ICommand
    {
        private Game1 myGame;

        public CommandEnablePartyLights(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.lightingManager.EnablePartyMode();
        }
    }
}
