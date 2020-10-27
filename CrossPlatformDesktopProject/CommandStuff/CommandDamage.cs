namespace Sprint0
{
    class CommandDamage : ICommand
    {
        private Game1 myGame;

        public CommandDamage(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.TakeDamage();
        }
    }
}
