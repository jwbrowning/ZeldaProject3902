﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class SpriteBow : IItem
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }

    public SpriteBow()
    {
        Position = new Vector2(400, 300);
        Sprite = ItemSpriteFactory.Instance.CreateSpriteBow();
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
