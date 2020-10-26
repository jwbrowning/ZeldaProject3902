﻿
using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.UsableItems;
using CrossPlatformDesktopProject.RoomManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Sprint0
{

	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		static public Texture2D environment,squareOutline;
		public IPlayer player;
		private List<IController> controllers;
		private SpriteFont font;
		private bool showCollisions = true;
		public iRoom currentRoom;
		public int roomIndex = 10;
		public string[] rooms = { "RoomA3", "RoomB1", "RoomB3", "RoomB4", "RoomB6", "RoomC1", "RoomC2", "RoomC3", "RoomC4", "RoomC5", "RoomC6", "RoomD3", "RoomD4", "RoomD6", "RoomE2", "RoomE3", "RoomF2"};
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		public void Reinitialize()
		{
			Initialize();
		}
		protected override void Initialize()
		{
			LoadContent();
			player = new Link(this);
			player.Position = new Vector2(200, 360);
			LinkSpriteFactory.Instance.player = player;

			controllers = new List<IController>();
			controllers.Add(new ControllerKeyboard(this));
			controllers.Add(new ControllerMouse(this));
			this.IsMouseVisible = true;
			base.Initialize();

			currentRoom = new Room1(this);
            currentRoom.loadRoom("RoomC6");

            currentRoom.Enemies.Add(new Aquamentus(this, new Vector2(400, 200)));
			currentRoom.Blocks.Add(new BlockStandard(new Vector2(200, 200)));
			currentRoom.Items.Add(new Map(new Vector2(300, 200)));
			
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			environment = Content.Load<Texture2D>("environment");
			squareOutline = Content.Load<Texture2D>("SquareOutline");
			BlockSpriteFactory.Instance.LoadAllTextures(Content);
			UsableItemSpriteFactory.Instance.LoadAllTextures(Content);
			NPCSpriteFactory.Instance.LoadAllTextures(Content);
			LinkSpriteFactory.Instance.LoadAllTextures(Content);
			ItemSpriteFactory.Instance.LoadAllTextures(Content);

			font = Content.Load<SpriteFont>("arial");

		}

		//unused, kept just in case
		protected override void UnloadContent()
		{
			//unused
		}



		protected override void Update(GameTime gameTime)
		{
			foreach (IController currentController in controllers)
			{
				currentController.Update();
			}

            for (int i = 0; i < currentRoom.NPCs.Count; i++)
            {
                currentRoom.NPCs[i].Update();
            }
            for (int i = 0; i < currentRoom.Enemies.Count; i++)
            {
                currentRoom.Enemies[i].Update();
            }
            for (int i = 0; i < currentRoom.Items.Count; i++)
            {
                currentRoom.Items[i].Update();
            }
            for (int i = 0; i < currentRoom.Blocks.Count; i++)
            {
                currentRoom.Blocks[i].Update();
            }

			player.Update();

            //if (npcs.Count > 0) npcs[0].Update();
            //if (items.Count > 0) items[0].Update();

            List<IGameObject> allGameObjects = currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player, player.Sword }).ToList();
            CollisionDetection.DetectCollisions(allGameObjects);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Gray);

            foreach (INPC npc in currentRoom.NPCs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in currentRoom.Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IItem item in currentRoom.Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in currentRoom.Blocks)
            {
                block.Draw(spriteBatch);
            }

			player.Draw(spriteBatch);

            // For testing, set showCollisions to true to show an outline around all colliders:
            if (showCollisions)
            {
                spriteBatch.Begin();
                foreach (IGameObject g in currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player, player.Sword }))
                {
                    Rectangle rec = CollisionDetection.GetColliderRectangle(g);
                    spriteBatch.Draw(squareOutline, rec, new Color(Color.LimeGreen, 1));
                }
                spriteBatch.End();
            }


			base.Draw(gameTime);
		}
	}
}
