
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D environment;
        public List<IGameObject> gameObjects;
        public List<INPC> npcs;
        public List<IBlock> blocks;
        public IPlayer player;
        private List<IController> controllers;
        private SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            LoadContent();
            gameObjects = new List<IGameObject>();
            player = new Link(this);
            player.Position = new Vector2(200, 360);
            LinkSpriteFactory.Instance.player = player;

            npcs = new List<INPC>();
            INPC blueKeeseSprite = new BlueKeese(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(blueKeeseSprite);
            INPC redKeeseSprite = new RedKeese(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(redKeeseSprite);
            INPC blackGelSprite = new BlackGel(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(blackGelSprite);
            INPC blackZolSprite = new BlackZol(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(blackZolSprite);
            INPC stalfosSprite = new Stalfos(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(stalfosSprite);
            INPC blueGoriyaSprite = new BlueGoriya(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(blueGoriyaSprite);
            INPC bladeTrapSprite = new BladeTrap(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(bladeTrapSprite);
            INPC ropeSprite = new Rope(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(ropeSprite);
            INPC wallMasterSprite = new WallMaster(NPCSpriteFactory.Instance.textureEnemies);
            npcs.Add(wallMasterSprite);
            INPC oldManSprite = new OldMan(NPCSpriteFactory.Instance.textureNPCs);
            npcs.Add(oldManSprite);
            INPC merchantSprite = new Merchant(NPCSpriteFactory.Instance.textureNPCs);
            npcs.Add(merchantSprite);
            INPC flameSprite = new Flame(NPCSpriteFactory.Instance.textureNPCs);
            npcs.Add(flameSprite);
            INPC aquamentusSprite = new Aquamentus(NPCSpriteFactory.Instance.textureBosses);
            npcs.Add(aquamentusSprite);
            INPC dodongoSprite = new Dodongo(NPCSpriteFactory.Instance.textureBosses);
            npcs.Add(dodongoSprite);

            blocks = new List<IBlock>();
            IBlock blockStandard = new BlockStandard(environment);
            blocks.Add(blockStandard);
            IBlock doorBombed = new DoorBombed(environment);
            blocks.Add(doorBombed);
            IBlock doorClosed = new DoorClosed(environment);
            blocks.Add(doorClosed);
            IBlock doorLocked = new DoorLocked(environment);
            blocks.Add(doorLocked);
            IBlock doorOpen = new DoorOpen(environment);
            blocks.Add(doorOpen);
            IBlock floorTile = new FloorTile(environment);
            blocks.Add(floorTile);
            IBlock gapTile = new GapTile(environment);
            blocks.Add(gapTile);
            //IBlock ladder = new Ladder(environment);
            //blocks.Add(ladder);
            //IBlock roomBorder = new RoomBorder(environment);
            //blocks.Add(roomBorder);
            IBlock stairs = new Stairs(environment);
            blocks.Add(stairs);
            IBlock statue = new Statue(environment);
            blocks.Add(statue);

            controllers = new List<IController>();
            controllers.Add(new ControllerKeyboard(this));
            //this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            environment = Content.Load<Texture2D>("environment");
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

            foreach (IGameObject currentGameObject in gameObjects)
            {
                currentGameObject.Update();
            }

            player.Update();

            if (npcs.Count > 0) npcs[0].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            foreach (IGameObject currentGameObject in gameObjects)
            {
                currentGameObject.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            if (npcs.Count > 0) npcs[0].Draw(spriteBatch);
            if (blocks.Count > 0) blocks[0].Draw(spriteBatch,Vector2.Zero);

            base.Draw(gameTime);
        }
    }
}
