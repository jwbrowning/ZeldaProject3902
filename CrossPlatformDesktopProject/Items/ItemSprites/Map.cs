﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

public class Map : IItem
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public ICollisionHandler CollisionHandler { get; set; }

    public Map(Vector2 position)
    {
        Position = position;
        Sprite = ItemSpriteFactory.Instance.CreateSpriteMap();
        CollisionHandler = new ItemCollisionHandler(this, 32, 32, 0, 0);
    }

    public void Update()
    {
        Sprite.Update();
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
    {
        Sprite.Draw(spriteBatch, parentPos + Position);
    }

    public void PickUp()
    {
        // No Implementation yet
    }
}
