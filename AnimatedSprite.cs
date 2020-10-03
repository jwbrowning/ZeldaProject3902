using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class Class1
{
	public Texture2D Texture { get; set; }
	public int Rows { get; set; }
	public int Columns { get; set; }
	private int currentFrame;
	private int totalFrames;

	public AnimatedSprite(Texture2D texture, int rows, int columns)
	{
		Texture = texture;
		Rows = rows;
		Columns = columns;
		currentFrame = 0;
		totalFrames = Rows * Columns;
	}

	public Class1()
	{
	}

}
