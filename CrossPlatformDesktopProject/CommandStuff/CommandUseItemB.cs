using CrossPlatformDesktopProject.HeadsUpDisplayStuff;

namespace Sprint0
{
    class CommandUseItemB : ICommand
    {
        private Game1 myGame;

        public CommandUseItemB(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            switch(myGame.hud.inventoryInfo.selectedItem)
            {
                case InventoryInfo.InventoryItem.Bomb:
                    myGame.player.UseBomb();
                    break;
                case InventoryInfo.InventoryItem.Boomerang:
                    myGame.player.ThrowBoomerang();
                    break;
                case InventoryInfo.InventoryItem.Bow:
                    myGame.player.ShootArrow();
                    break;
            }
        }
    }
}
