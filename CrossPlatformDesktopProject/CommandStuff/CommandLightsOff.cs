namespace Sprint0
{
    class CommandLightsOff : ICommand
    {
        private Game1 myGame;

        public CommandLightsOff(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.lightingManager.TurnOffLights();
        }
    }
}
