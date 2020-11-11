
using CrossPlatformDesktopProject;
using CrossPlatformDesktopProject.CollisionStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.HeadsUpDisplayStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.RoomManagement;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{

    public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		static public Texture2D environment,squareOutline,floortilebase;
		public Texture2D rect;
		public IPlayer player;
		private HeadsUpDisplay hud;
		private List<IController> controllers;
		public SpriteFont font;
		public bool showCollisions = false;
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
			player.Position = new Vector2(200, 360);
			LinkSpriteFactory.Instance.player = player;

			hud = new HeadsUpDisplay(this, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

			controllers = new List<IController>();
			controllers.Add(new ControllerKeyboard(this));
			controllers.Add(new ControllerMouse(this));
			this.IsMouseVisible = true;
			base.Initialize();

			currentRoom = new Room1(this, new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2+84), floortilebase);
            currentRoom.loadRoom("RoomDEBUG");
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

			hud.Update();

			currentRoom.Update();

			player.Update();

            List<IGameObject> allGameObjects = currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player, player.Sword }).ToList();
            CollisionDetection.DetectCollisions(allGameObjects);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			currentRoom.Draw(spriteBatch);

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

			hud.Draw(spriteBatch);

			base.Draw(gameTime);
		}

		public void Pause()
        {
			hud.Pause();
        }

		public void Unpause()
        {
			hud.Unpause();
        }
	}
}
