using CrossPlatformDesktopProject.PlayerStuff;

namespace Sprint0
{
    class CommandUnlimitedWeapons : ICommand
    {
        private Game1 myGame;

        public CommandUnlimitedWeapons(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.ItemCounts[ItemType.Rupee] = 100000;
            myGame.player.ItemCounts[ItemType.Bomb] = 100000;
        }
    }
}
