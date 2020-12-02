namespace Sprint0
{
    class CommandDisablePartyLights : ICommand
    {
        private Game1 myGame;

        public CommandDisablePartyLights(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.lightingManager.DisablePartyMode();
        }
    }
}
