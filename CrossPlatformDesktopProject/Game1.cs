
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

namespace Sprint0
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static public Texture2D environment,squareOutline;
        //public List<IGameObject> gameObjects;
        //public List<INPC> npcs;
        //public List<IEnemy> enemies;
        //public List<IBlock> blocks;
        //public List<IItem> items;
        public IPlayer player;
        private List<IController> controllers;
        private SpriteFont font;
        private bool showCollisions = true;
        public iRoom currentRoom;

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
            
            /*
            gameObjects = new List<IGameObject>();
            npcs = new List<INPC>();
            enemies = new List<IEnemy>();
            blocks = new List<IBlock>();
            items = new List<IItem>();
            */


            controllers = new List<IController>();
            controllers.Add(new ControllerKeyboard(this));
            controllers.Add(new ControllerMouse(this));
            this.IsMouseVisible = true;
            base.Initialize();

            currentRoom = new Room1(player);
            currentRoom.loadRoom("RoomC6");
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

            foreach (INPC npc in currentRoom.NPCs)
            {
                npc.Update();
            }
            foreach (IEnemy enemy in currentRoom.Enemies)
            {
                enemy.Update();
            }
            foreach (IItem item in currentRoom.Items)
            {
                item.Update();
            }
            foreach (IBlock block in currentRoom.Blocks)
            {
                block.Update();
            }

            player.Update();

            //if (npcs.Count > 0) npcs[0].Update();
            //if (items.Count > 0) items[0].Update();

            List<IGameObject> allGameObjects = currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player }).ToList();
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
            foreach (IEnemy enemy in currentRoom.NPCs)
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
                foreach (IGameObject g in currentRoom.Blocks.Concat<IGameObject>(currentRoom.Items).Concat(currentRoom.Enemies).Concat(currentRoom.NPCs).Concat(player.ActiveItems).Concat(new List<IGameObject>() { player }))
                {
                    Rectangle rec = CollisionDetection.GetColliderRectangle(g);
                    spriteBatch.Draw(squareOutline, rec, new Color(Color.LimeGreen, 1));
                }
                spriteBatch.End();
            }

            //if (npcs.Count > 0) npcs[0].Draw(spriteBatch);
            //if (blocks.Count > 0) blocks[0].Draw(spriteBatch,Vector2.Zero);
            //if (items.Count > 0) items[0].Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
