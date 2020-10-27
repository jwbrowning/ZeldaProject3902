using CrossPlatformDesktopProject.PlayerStuff;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    public interface IUsableItem : IGameObject
    {
        ISprite Sprite { get; set; }
    }
}
