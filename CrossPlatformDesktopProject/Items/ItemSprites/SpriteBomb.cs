﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using System;

public class SpriteBomb : IItem
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public ICollisionHandler CollisionHandler { get; set; }

    public SpriteBomb()
    {
        Position = new Vector2(400, 300);
        Sprite = ItemSpriteFactory.Instance.CreateSpriteBomb();
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
