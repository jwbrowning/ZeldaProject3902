using CrossPlatformDesktopProject.PlayerStuff;
using Sprint0;

public interface IItem : IGameObject
{
    ISprite Sprite { get; set; }
    void PickUp();
}
