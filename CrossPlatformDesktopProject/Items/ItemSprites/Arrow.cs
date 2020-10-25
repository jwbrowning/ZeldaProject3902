using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Items;
using System;
using Sprint0;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;

public class Arrow : IItem
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public ICollisionHandler CollisionHandler { get; set; }

    public Arrow(Vector2 position)
    {
        Position = position;
        Sprite = ItemSpriteFactory.Instance.CreateSpriteArrow();
        CollisionHandler = new ItemCollisionHandler(this, 32, 32, 0, 0);
    }

    public void Update()
    {
        Sprite.Update();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position);
    }

    public void PickUp()
    {
        // No Implementation yet
    }
}
