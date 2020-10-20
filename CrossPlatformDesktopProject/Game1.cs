
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.UsableItems;
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
        public List<IEnemy> enemies;
        public List<IBlock> blocks;
        public List<IItem> items;
        public IPlayer player;
        private List<IController> controllers;
        private SpriteFont font;

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
            
            gameObjects = new List<IGameObject>();
            npcs = new List<INPC>();
            enemies = new List<IEnemy>();
            blocks = new List<IBlock>();
            items = new List<IItem>();

            items.Add(new SpriteHeart());
            npcs.Add(new OldMan(NPCSpriteFactory.Instance.textureNPCs));
            enemies.Add(new BlueKeese(NPCSpriteFactory.Instance.textureEnemies));
            blocks.Add(new BlockStandard(environment));

            /* Sprint 2 Stuff - can prob delete now
            items = new List<IItem>();
            IItem arrow = new SpriteArrow();
            items.Add(arrow);
            IItem bomb = new SpriteBomb();
            items.Add(bomb);
            IItem boomerang = new SpriteBoomerang();
            items.Add(boomerang);
            IItem bow = new SpriteBow();
            items.Add(bow);
            IItem clock = new SpriteClock();
            items.Add(clock);
            IItem compass = new SpriteCompass();
            items.Add(compass);
            IItem fairy = new SpriteFairy();
            items.Add(fairy);
            IItem heart = new SpriteHeart();
            items.Add(heart);
            IItem heartContainer = new SpriteHeartContainer();
            items.Add(heartContainer);
            IItem key = new SpriteKey();
            items.Add(key);
            IItem map = new SpriteMap();
            items.Add(map);
            IItem rupee = new SpriteRupee();
            items.Add(rupee);
            IItem triforcePiece = new SpriteTriforcePiece();
            items.Add(triforcePiece);

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
            */

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

            foreach (IGameObject currentGameObject in gameObjects)
            {
                currentGameObject.Update();
            }
            foreach (INPC npc in npcs)
            {
                npc.Update();
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update();
            }
            foreach (IItem item in items)
            {
                item.Update();
            }

            player.Update();

            //if (npcs.Count > 0) npcs[0].Update();
            //if (items.Count > 0) items[0].Update();
            DetectCollisions();

            base.Update(gameTime);
        }

        private void DetectCollisions()
        {
            Rectangle playerRect = new Rectangle((int)(player.Position.X + player.CollisionHandler.Collider.Offset.X), (int)(player.Position.Y + player.CollisionHandler.Collider.Offset.Y), (int)player.CollisionHandler.Collider.Size.X, (int)player.CollisionHandler.Collider.Size.Y);
            foreach(INPC npc in npcs)
            {
                // PLAYER VS NPC
                Rectangle rect = GetColliderRectangle(npc);
                Rectangle intersect = Rectangle.Intersect(playerRect, rect);
                if(!intersect.IsEmpty)
                {
                    player.CollisionHandler.HandleNPCCollision(npc.CollisionHandler.Collider);
                    npc.CollisionHandler.HandlePlayerCollision(player.CollisionHandler.Collider);
                }
            }
            foreach(IEnemy enemy in enemies)
            {
                // PLAYER VS ENEMY
                Rectangle rect = GetColliderRectangle(enemy);
                Rectangle intersect = Rectangle.Intersect(playerRect, rect);
                if (!intersect.IsEmpty)
                {
                    player.CollisionHandler.HandleEnemyCollision(enemy.CollisionHandler.Collider);
                    enemy.CollisionHandler.HandlePlayerCollision(player.CollisionHandler.Collider);
                }

                // ENEMY VS USABLEITEM
                foreach (IUsableItem usableItem in player.ActiveItems)
                {
                    Rectangle rect2 = GetColliderRectangle(usableItem);
                    Rectangle intersect2 = Rectangle.Intersect(playerRect, rect);
                    if (!intersect2.IsEmpty)
                    {
                        enemy.CollisionHandler.HandleUsableItemCollision(usableItem.CollisionHandler.Collider);
                        usableItem.CollisionHandler.HandleEnemyCollision(enemy.CollisionHandler.Collider);
                    }
                }

                // ENEMY VS BLOCK
                foreach (IBlock block in blocks)
                {
                    Rectangle rect2 = GetColliderRectangle(block);
                    Rectangle intersect2 = Rectangle.Intersect(playerRect, rect);
                    if (!intersect2.IsEmpty)
                    {
                        enemy.CollisionHandler.HandleBlockCollision(block.CollisionHandler.Collider);
                        block.CollisionHandler.HandleEnemyCollision(enemy.CollisionHandler.Collider);
                    }
                }
            }
            foreach (IItem item in items)
            {
                // PLAYER VS ITEM
                Rectangle rect = GetColliderRectangle(item);
                Rectangle intersect = Rectangle.Intersect(playerRect, rect);
                if (!intersect.IsEmpty)
                {
                    player.CollisionHandler.HandlePickupItemCollision(item.CollisionHandler.Collider);
                    item.CollisionHandler.HandlePlayerCollision(player.CollisionHandler.Collider);
                }
            }
            foreach (IUsableItem usableItem in player.ActiveItems)
            {
                // PLAYER VS USABLEITEM
                Rectangle rect = GetColliderRectangle(usableItem);
                Rectangle intersect = Rectangle.Intersect(playerRect, rect);
                if (!intersect.IsEmpty)
                {
                    player.CollisionHandler.HandleUsableItemCollision(usableItem.CollisionHandler.Collider);
                    usableItem.CollisionHandler.HandlePlayerCollision(player.CollisionHandler.Collider);
                }

                // USABLEITEM VS BLOCK
                foreach (IBlock block in blocks)
                {
                    Rectangle rect2 = GetColliderRectangle(block);
                    Rectangle intersect2 = Rectangle.Intersect(playerRect, rect);
                    if (!intersect2.IsEmpty)
                    {
                        usableItem.CollisionHandler.HandleBlockCollision(block.CollisionHandler.Collider);
                        block.CollisionHandler.HandleEnemyCollision(usableItem.CollisionHandler.Collider);
                    }
                }
            }
            foreach (IBlock block in blocks)
            {
                // PLAYER VS BLOCK
                Rectangle rect = GetColliderRectangle(block);
                Rectangle intersect = Rectangle.Intersect(playerRect, rect);
                if (!intersect.IsEmpty)
                {
                    player.CollisionHandler.HandleBlockCollision(block.CollisionHandler.Collider);
                    block.CollisionHandler.HandlePlayerCollision(player.CollisionHandler.Collider);
                }
            }
        }

        private Rectangle GetColliderRectangle(IGameObject gameObject)
        {
            return new Rectangle((int)(gameObject.Position.X + gameObject.CollisionHandler.Collider.Offset.X), (int)(gameObject.Position.Y + gameObject.CollisionHandler.Collider.Offset.Y), (int)gameObject.CollisionHandler.Collider.Size.X, (int)gameObject.CollisionHandler.Collider.Size.Y);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            foreach (IGameObject currentGameObject in gameObjects)
            {
                currentGameObject.Draw(spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IItem item in items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch, Vector2.Zero);
            }

            //Test Collider Stuff:
            /*if (npcs.Count > 0)
            {
                Rectangle p = player.CollisionHandler.Collider.ColliderRectangle;
                Rectangle n = npcs[0].CollisionHandler.Collider.ColliderRectangle;
                spriteBatch.Begin();
                spriteBatch.Draw(environment, p, Color.CadetBlue);
                spriteBatch.Draw(environment, n, Color.IndianRed);
                spriteBatch.End();
            }*/

            player.Draw(spriteBatch);

            //if (npcs.Count > 0) npcs[0].Draw(spriteBatch);
            //if (blocks.Count > 0) blocks[0].Draw(spriteBatch,Vector2.Zero);
            //if (items.Count > 0) items[0].Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
