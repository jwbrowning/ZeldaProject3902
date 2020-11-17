
using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.GameStateStuff;
using CrossPlatformDesktopProject.GameStateStuff.GameStateClasses;
using CrossPlatformDesktopProject.HeadsUpDisplayStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.RoomManagement;
using CrossPlatformDesktopProject.ScreenStuff;
using CrossPlatformDesktopProject.SoundManagement;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{

    public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public SpriteFont font;

		public bool showCollisions = false;
		public bool playerDebug = true;

		static public Texture2D environment,squareOutline,floortilebase;
		public Texture2D rect;

		public IPlayer player;
		public HeadsUpDisplay hud;
		public IScreen screen;
		private IGameState gameState;

		public iRoom currentRoom;
		public int roomIndex = 0;
		public string[] rooms = {"RoomDEBUG", "RoomA3", "RoomB1", "RoomB3", "RoomB4", "RoomB6", "RoomC1", "RoomC2", "RoomC3", "RoomC4", "RoomC5", "RoomC6", "RoomD3", "RoomD4", "RoomD6", "RoomE2", "RoomE3", "RoomF2"};

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = 1024 + 64;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = 704 + 112*2;   // set this value to the desired height of your window
			graphics.ApplyChanges();
		}

		public void Reinitialize()
		{
			Initialize();
		}
		protected override void Initialize()
		{
			LoadContent();
			player = new Link(this);
			player.Position = new Vector2(0, 160);
			LinkSpriteFactory.Instance.player = player;
			if(playerDebug)
			{
				player.Health = 1000;
				player.TotalHealth = 1000;
				player.ItemCounts[ItemType.Map]++;
				player.ItemCounts[ItemType.Compass]++;
			}

			hud = new HeadsUpDisplay(this, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
			screen = new NormalScreen(this, GraphicsDevice, graphics);
			gameState = new NormalGameState(this);

			this.IsMouseVisible = true;
			base.Initialize();

			currentRoom = new Room1(this, new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2+84), floortilebase);
            currentRoom.LoadRoom("RoomC6");
			//currentRoom.LoadRoom("RoomDEBUG");
			roomIndex = Array.FindIndex(rooms, x => x == "RoomC6");

			//SoundFactory.Instance.musicDungeonLoop.Play();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			rect = new Texture2D(graphics.GraphicsDevice, 1, 1);
			rect.SetData(new[] { Color.White });
			environment = Content.Load<Texture2D>("environment");
			squareOutline = Content.Load<Texture2D>("SquareOutline");
			floortilebase = Content.Load<Texture2D>("floortilewithwall");
			HUDSpriteFactory.Instance.LoadAllTextures(Content);
			BlockSpriteFactory.Instance.LoadAllTextures(Content);
			UsableItemSpriteFactory.Instance.LoadAllTextures(Content);
			NPCSpriteFactory.Instance.LoadAllTextures(Content);
			LinkSpriteFactory.Instance.LoadAllTextures(Content);
			ItemSpriteFactory.Instance.LoadAllTextures(Content);
			DoorSpriteFactory.Instance.LoadAllTextures(Content);
			WallSpriteFactory.Instance.LoadAllTextures(Content);
			SoundFactory.Instance.LoadAllSounds(Content);

			font = Content.Load<SpriteFont>("arial");

		}

		//unused, kept just in case
		protected override void UnloadContent()
		{
			//unused
		}

		protected override void Update(GameTime gameTime)
		{
			gameState.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			screen.Draw(spriteBatch);
			gameState.Draw(spriteBatch);

            // For testing, set showCollisions to true to show an outline around all colliders:
            if (showCollisions)
            {
                spriteBatch.Begin();
                foreach (IGameObject g in currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player, player.Sword }))
                {
                    Rectangle rec = CollisionDetection.GetColliderRectangle(g, currentRoom.Position);
                    spriteBatch.Draw(squareOutline, rec, new Color(Color.LimeGreen, 1));
				}
				/*foreach (IGameObject g in currentRoom.Walls)
				{
					Rectangle rec = CollisionDetection.GetColliderRectangle(g, currentRoom.Position);
					spriteBatch.Draw(squareOutline, rec, new Color(Color.Coral, .5f));
				}*/
				foreach (IGameObject g in currentRoom.Doors)
				{
					Rectangle rec = CollisionDetection.GetColliderRectangle(g, currentRoom.Position);
					spriteBatch.Draw(squareOutline, rec, Color.Blue);
				}
				spriteBatch.End();
			}

			base.Draw(gameTime);
		}
		public void FinishTransition(iRoom room)
        {
			currentRoom = room;
			gameState = new NormalGameState(this);
			player.CollisionHandler = new LinkCollisionHandler(this, player, 56, 50, 0, 10);
		}
		public void Pause()
        {
			screen = new PauseScreen(this, GraphicsDevice, graphics);
			gameState = new PausedGameState(this);
        }

		public void Unpause()
        {
			screen = new NormalScreen(this, GraphicsDevice, graphics);
			gameState = new NormalGameState(this);
		}

		public void OpenInventory()
		{
			hud.OpenInventory();
			gameState = new InventoryGameState(this);
		}

		public void CloseInventory()
		{
			hud.CloseInventory();
			gameState = new NormalGameState(this);
		}

		public void GameOver()
        {
			screen = new GameOverScreen(this, GraphicsDevice, graphics);
			gameState = new GameOverGameState(this);
        }

		public void Win()
		{
			screen = new WinScreen(this, GraphicsDevice, graphics);
			gameState = new WinningGameState(this);
		}

		public void ChangeRoom(string nextRoomName, string direction)
        {
			player.CollisionHandler = new EmptyCollisionHandler(player);
			gameState = new RoomTransitionGameState(this);
			currentRoom.ChangeRoom(nextRoomName, direction);
			roomIndex = Array.FindIndex(rooms, x => x == nextRoomName);
			player.ActiveItems.Clear();
			player.ItemCounts[ItemType.Clock] = 0;
        }
	}
}
