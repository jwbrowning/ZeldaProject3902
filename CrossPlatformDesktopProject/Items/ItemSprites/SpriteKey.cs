﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class SpriteKey : IItem
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public ICollisionHandler CollisionHandler { get; set; }

    public SpriteKey()
    {
        Position = new Vector2(400, 300);
        Sprite = ItemSpriteFactory.Instance.CreateSpriteKey();
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
