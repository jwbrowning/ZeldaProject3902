namespace Sprint0
{
    class CommandLightsOn : ICommand
    {
        private Game1 myGame;

        public CommandLightsOn(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.lightingManager.TurnOnLights();
        }
    }
}
