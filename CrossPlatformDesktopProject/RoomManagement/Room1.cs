﻿using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;

namespace CrossPlatformDesktopProject.RoomManagement
{
    class Room1 : iRoom
	{
		private Game1 mygame;
		public List<IEnemy> Enemies { get; set; }
        public List<IBlock> Blocks { get; set; }
		public List<IItem> Items { get; set; }
		public List<INPC> NPCs { get; set; }
		public List<IDoor> Doors {get; set; }
		public List<IItem> HiddenItems { get; set; }
		public List<IWall> Walls { get; set; }
		public Vector2 Position { get; set; }
		private Texture2D floorBaseWithWalls;
		private Vector2 size = new Vector2(1024,704);
		public Vector2 Destination { get; set; }
		private string CurrentRoom;
		public iRoom nextRoom { get; set; }
		public Texture2D Background { get; set; }
		private float roomTransitionSpeed = 16f;
		public string Dialogue { get; set; }

		/*XSCALE and YSCALE convert the object coordinates from tiles to pixels. 
		In the original game each tile is 16 pixels wide, but upscaled by 4 for 
		visibility so each tile is actually 64 pixels*/
		const int XSCALE = 64;
		const int YSCALE = 64;
		/*Offsets are used to shift the tile grid down and to the right
		to account for the border walls and HUD. Even though the border wall
		is only 64 pixels wide, 32 pixels are added to account for the sprite's
		Draw methods using the center of the sprite, not the top left corner*/
		int XOFFSET = 96;
		int YOFFSET = 96;
		public Room1(Game1 game, Vector2 position, Texture2D floorBaseWithWalls)
		{
			mygame = game;
			Enemies = new List<IEnemy>();
			Blocks = new List<IBlock>();
			Items = new List<IItem>();
			NPCs = new List<INPC>();
			Doors = new List<IDoor>();
			Walls = new List<IWall>();
			HiddenItems = new List<IItem>();
			Position = position;
			this.floorBaseWithWalls = floorBaseWithWalls;
			XOFFSET = 96 + (int)( - size.X / 2f);
			YOFFSET = 96 + (int)( - size.Y / 2f);
			Destination = position;
			Background = floorBaseWithWalls;
		}
		
		public void ChangeRoom(string nextRoomName, string direction)
		{
			Vector2 position = Vector2.Zero;
			Vector2 comingUpLocation = new Vector2(6.5f * XSCALE + XOFFSET, 7 * YSCALE + YOFFSET);
			Vector2 comingDownLocation = new Vector2(6.5f * XSCALE + XOFFSET, 1 * YSCALE + YOFFSET);
			Vector2 comingRightLocation = new Vector2(1 * XSCALE + XOFFSET, 4f * YSCALE + YOFFSET);
			Vector2 comingLeftLocation = new Vector2(12 * XSCALE + XOFFSET, 4f * YSCALE + YOFFSET);
			if (direction == "Up")
			{
				Destination = Position + new Vector2(0, size.Y);
				position = Position + new Vector2(0, -size.Y);
				mygame.player.Position = comingUpLocation;
			}
			else if(direction == "Down")
			{
				Destination = Position + new Vector2(0, -size.Y);
				position = Position + new Vector2(0, size.Y);
				mygame.player.Position = comingDownLocation;
			}
			else if (direction == "Right")
			{
				Destination = Position + new Vector2(-size.X, 0);
				position = Position + new Vector2(size.X, 0);
				mygame.player.Position = comingRightLocation;
			}
			else if (direction == "Left")
			{
				Destination = Position + new Vector2(size.X, 0);
				position = Position + new Vector2(-size.X, 0);
				mygame.player.Position = comingLeftLocation;
			}
            nextRoom = new Room1(mygame, position, floorBaseWithWalls)
            {
                Destination = Position
            };
            nextRoom.LoadRoom(nextRoomName);
		}
		public void addWalls()
        {
			int length = 10;
			int width = 12;
			Vector2 doorOffset = new Vector2(32, 32);
			Vector2 upLocation = new Vector2(6, 0);
			Vector2 downLocation = new Vector2(6, 9);
			Vector2 leftLocation = new Vector2(-1, 4.5f);
			Vector2 rightLocation = new Vector2(13, 4.5f);
			for (int k=0;k<width;k++)
            {
				if(k<length)
                {
					Walls.Add(new Wall(new Vector2(leftLocation.X * XSCALE + doorOffset.X + XOFFSET, k * YSCALE - doorOffset.Y + YOFFSET)));
					Walls.Add(new Wall(new Vector2(rightLocation.X * XSCALE + doorOffset.X + XOFFSET, k * YSCALE - doorOffset.Y + YOFFSET)));
				}
				Walls.Add(new Wall(new Vector2((k * XSCALE) + doorOffset.X + XOFFSET, upLocation.Y * YSCALE - doorOffset.Y + YOFFSET)));
				Walls.Add(new Wall(new Vector2((k * XSCALE) + doorOffset.X + XOFFSET, downLocation.Y * YSCALE - doorOffset.Y + YOFFSET)));

			}
        }

		public void LoadRoom(string roomName)
		{
			Enemies.Clear();
			Blocks.Clear();
			Items.Clear();
			NPCs.Clear();
			Doors.Clear();
			Walls.Clear();
			HiddenItems.Clear();
			Dialogue = "";

			CurrentRoom = roomName;

			//moves Link to the bottom of the map to avoid issues where blocks would spawn on top of him
			//mygame.player.Position = new Vector2(6 * XSCALE + XOFFSET, 7 * YSCALE + YOFFSET);

			addWalls();

			XElement roomFile = XElement.Load("../../../../Content/Rooms/" + roomName + ".xml");

			if (roomFile.Descendants("Background").Count() > 0)	
            {
				Console.WriteLine(roomFile.Descendants("Background").Count());
				if (roomFile.Element("Asset").Element("Background").Value == "RoomBowBackground")
                {
					Background = BlockSpriteFactory.Instance.RoomBowBackground;
                }
				else if (roomFile.Element("Asset").Element("Background").Value == "BlackWithWallBackground")
                {
					Background = BlockSpriteFactory.Instance.BlackWithWallBackground;
                }
            }
            else
            {
				Background = floorBaseWithWalls;
            }

			IEnumerable <XElement> loadedEnvironmentObjects = from item in roomFile.Descendants("Item")
					  where (string)item.Element("ObjectType") == "Environment"
					  select item;
			foreach (XElement environmentObject in loadedEnvironmentObjects) {
				AddEnvironmentObject(environmentObject);
			}
			IEnumerable<XElement> loadedEnemies = from item in roomFile.Descendants("Item")
															 where (string)item.Element("ObjectType") == "Enemy"
															 select item;
			foreach (XElement enemyObject in loadedEnemies)
			{
				AddEnemy(enemyObject);
				Thread.Sleep(20); //used so the random number generator for enemies don't have the same seed. It's time based and without this they have the same seed. 
			}
			IEnumerable<XElement> loadedItems = from item in roomFile.Descendants("Item")
												  where (string)item.Element("ObjectType") == "Item"
												  select item;
			foreach (XElement itemObject in loadedItems)
			{
				AddItem(itemObject, Items);
			}

			IEnumerable<XElement> loadedHiddenItems = from item in roomFile.Descendants("Item")
													  where (string)item.Element("ObjectType") == "HiddenItem"
													  select item;
			foreach (XElement itemObject in loadedHiddenItems)
			{
				AddItem(itemObject, HiddenItems);
			}

			IEnumerable<XElement> loadedNPCs = from item in roomFile.Descendants("Item")
												where (string)item.Element("ObjectType") == "NPC"
												select item;
			foreach (XElement NPCObject in loadedNPCs)
			{
				AddNPC(NPCObject);
			}
			IEnumerable<XElement> loadedDoors = from item in roomFile.Descendants("Door")
												select item;
			foreach (XElement DoorObject in loadedDoors)
			{
				AddDoor(DoorObject);
			}
		}

		public void RespawnEnemies()
		{
			throw new NotImplementedException();
		}

		void AddEnvironmentObject(XElement environmentObject)
		{
			string[] location = ((string)environmentObject.Element("Location")).Split(' ');
			int x = int.Parse(location[0]);
			int y = int.Parse(location[1]);

			if ((string) environmentObject.Element("ObjectName") == "BlockStandard")
			{
				Blocks.Add(new BlockStandard(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "StatueFish")
			{
				Blocks.Add(new Statue(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "StatueDragon")
			{
				Blocks.Add(new StatueDragon(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "Stairs")
			{
				Blocks.Add(new Stairs(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "InvisibleStairs")
			{
				Blocks.Add(new StairsInvisible(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "InvisibleBlock")
			{
				Blocks.Add(new BlockInvisible(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "BlockMovable")
			{
				//TODO: Implement BlockMovable
				//Blocks.Add(new BlockMovable(Game1.environment, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)environmentObject.Element("ObjectName") == "Water")
			{
				Blocks.Add(new BlockWater(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else
			{
				Console.WriteLine("ERROR: " + (string)environmentObject.Element("ObjectName") + " is not a recognized block.");
			}
		}

		void AddEnemy(XElement enemy)
		{
			string[] location = ((string)enemy.Element("Location")).Split(' ');
			int x = int.Parse(location[0]);
			int y = int.Parse(location[1]);

			IEnemy createdEnemy;

			if ((string)enemy.Element("ObjectName") == "BlueKeese")
			{
				createdEnemy = (new BlueKeese(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "RedGoriya")
			{
				createdEnemy = (new BlueGoriya(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "Stalfos")
			{
				createdEnemy = (new Stalfos(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "BlackGel")
			{
				createdEnemy = (new BlackGel(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "BladeTrap")
			{
				createdEnemy = (new BladeTrap(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "WallMaster")
			{
				createdEnemy = (new WallMaster(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "Aquamentus")
			{
				createdEnemy = (new Aquamentus(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "Flame")
			{
				createdEnemy = (new Flame(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)enemy.Element("ObjectName") == "Wallmaster")
			{
				createdEnemy = (new WallMaster(mygame, new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else
			{
				Console.WriteLine("ERROR: " + (string)enemy.Element("ObjectName") + " is not a recognized enemy.");
				return;
			}

			if (enemy.Descendants("DropsItem").Count() > 0)
            {
				createdEnemy.carriedLoot = enemy.Element("DropsItem").Value;
            }

			Enemies.Add(createdEnemy);
		}

		void AddNPC(XElement NPC)
		{
			string[] location = ((string)NPC.Element("Location")).Split(' ');
			int x = int.Parse(location[0]);
			int y = int.Parse(location[1]);

			if ((string)NPC.Element("ObjectName") == "OldMan")
			{
				NPCs.Add(new OldMan(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
				Dialogue = NPC.Element("Dialogue").Value;
			}
			else
			{
				Console.WriteLine("ERROR: " + (string)NPC.Element("ObjectName") + " is not a recognized NPC.");
			}
		}

		void AddItem(XElement itemObject, List<IItem> list)
		{
			string[] location = ((string)itemObject.Element("Location")).Split(' ');
			int x = int.Parse(location[0]);
			int y = int.Parse(location[1]);

			if ((string)itemObject.Element("ObjectName") == "Boomerang")
			{
				list.Add(new Boomerang(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Bow")
			{
				list.Add(new Bow(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Key")
			{
				list.Add(new Key(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Map")
			{
                list.Add(new Map(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Compass")
			{
				list.Add(new Compass(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "HeartContainer")
			{
				list.Add(new HeartContainer(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "TriforcePiece")
			{
				list.Add(new TriforcePiece(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Arrows")
			{
				list.Add(new Arrow(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Bomb")
			{
				list.Add(new Bomb(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Clock")
			{
				list.Add(new Clock(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Fairy")
			{
				list.Add(new Fairy(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Heart")
			{
				list.Add(new Heart(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else if ((string)itemObject.Element("ObjectName") == "Rupee")
			{
				list.Add(new Rupee(new Vector2(x * XSCALE + XOFFSET, y * YSCALE + YOFFSET)));
			}
			else
			{
				Console.WriteLine("ERROR: " + (string)itemObject.Element("ObjectName") + " is not a recognized item.");
			}
		}
		
		void AddDoor(XElement doorObject)
		{
			string next = (string)doorObject.Element("DoorDestination");
			Vector2 doorOffset = new Vector2(32,32);
			Vector2 upLocation = new Vector2(6, 0);
			Vector2 downLocation = new Vector2(6, 9);
			Vector2 leftLocation = new Vector2(-1, 4.5f);
			Vector2 rightLocation = new Vector2(13, 4.5f);
			if ((string)doorObject.Element("DoorPosition") == "Up") {
				Vector2 doorLocation = new Vector2(upLocation.X * XSCALE + doorOffset.X + XOFFSET, upLocation.Y * YSCALE - doorOffset.Y + YOFFSET);
				if ((string)doorObject.Element("DoorType") == "Closed")
				{
					Doors.Add(new DoorClosed(doorLocation, "Up", next));
				}
				if ((string)doorObject.Element("DoorType") == "Open")
				{
					Doors.Add(new DoorOpen(doorLocation, "Up", next));
				}
				if ((string)doorObject.Element("DoorType") == "Locked")
				{
					Doors.Add(new DoorLocked(doorLocation, "Up", next, CurrentRoom));
				}
				if ((string)doorObject.Element("DoorType") == "Bombable")
				{
					Doors.Add(new DoorBombed(doorLocation, "Up", next, CurrentRoom));
				}
			} else if((string)doorObject.Element("DoorPosition") == "Down")
			{
				Vector2 doorLocation = new Vector2(downLocation.X * XSCALE + doorOffset.X + XOFFSET, downLocation.Y * YSCALE - doorOffset.Y + YOFFSET);
				if ((string)doorObject.Element("DoorType") == "Closed")
				{
					Doors.Add(new DoorClosed(doorLocation, "Down",next));
				}
				if ((string)doorObject.Element("DoorType") == "Open")
				{
					Doors.Add(new DoorOpen(doorLocation, "Down",next));
				}
				if ((string)doorObject.Element("DoorType") == "Locked")
				{
					Doors.Add(new DoorLocked(doorLocation, "Down",next, CurrentRoom));
				}
				if ((string)doorObject.Element("DoorType") == "Bombable")
				{
					Doors.Add(new DoorBombed(doorLocation, "Down",next, CurrentRoom));
				}
			} else if ((string)doorObject.Element("DoorPosition") == "Left")
			{
				Vector2 doorLocation = new Vector2(leftLocation.X * XSCALE + doorOffset.X + XOFFSET, leftLocation.Y * YSCALE - doorOffset.Y + YOFFSET);
				if ((string)doorObject.Element("DoorType") == "Closed")
				{
					Doors.Add(new DoorClosed(doorLocation, "Left", next));
				}
				if ((string)doorObject.Element("DoorType") == "Open")
				{
					Doors.Add(new DoorOpen(doorLocation, "Left", next));
				}
				if ((string)doorObject.Element("DoorType") == "Locked")
				{
					Doors.Add(new DoorLocked(doorLocation, "Left", next, CurrentRoom));
				}
				if ((string)doorObject.Element("DoorType") == "Bombable")
				{
					Doors.Add(new DoorBombed(doorLocation, "Left", next, CurrentRoom));
				}
			} else if ((string)doorObject.Element("DoorPosition") == "Right")
			{
				Vector2 doorLocation = new Vector2(rightLocation.X * XSCALE + doorOffset.X + XOFFSET, rightLocation.Y * YSCALE - doorOffset.Y + YOFFSET);
				if ((string)doorObject.Element("DoorType") == "Closed")
				{
					Doors.Add(new DoorClosed(doorLocation, "Right", next));
				}
				if ((string)doorObject.Element("DoorType") == "Open")
				{
					Doors.Add(new DoorOpen(doorLocation, "Right", next));
				}
				if ((string)doorObject.Element("DoorType") == "Locked")
				{
					Doors.Add(new DoorLocked(doorLocation, "Right", next, CurrentRoom));
				}
				if ((string)doorObject.Element("DoorType") == "Bombable")
				{
					Doors.Add(new DoorBombed(doorLocation, "Right", next, CurrentRoom));
				}
			}
		}
		
		public void UpdateRooms()
        {
			//Position = Vector2.Lerp(Position, Destination, lerpSpeed);
			Vector2 direction = (Destination - Position);
			direction.Normalize();
			Position += direction * roomTransitionSpeed;
			if(Vector2.Distance(Position,Destination) < 3 && nextRoom == null){
				Position = Destination;
				mygame.FinishTransition(this);
            }
		}

		public void UpdateNPCS()
		{
			for (int i = 0; i < NPCs.Count; i++)
			{
				NPCs[i].Update();
			}
		}

		public void UpdateEnemies()
		{
			for (int i = 0; i < Enemies.Count; i++)
			{
				Enemies[i].Update();
			}
		}

		public void UpdateItems()
		{
			for (int i = 0; i < Items.Count; i++)
			{
				Items[i].Update();
			}
		}

		public void UpdateBlocks()
		{
			for (int i = 0; i < Blocks.Count; i++)
			{
				Blocks[i].Update();
			}
		}

		public void UpdateDoors()
		{
			for (int i = 0; i < Doors.Count; i++)
			{
				Doors[i].Update();
			}
		}

		public void UpdateWalls()
		{
			for (int i = 0; i < Walls.Count; i++)
			{
				Walls[i].Update();
			}
		}

		public void DrawBackground(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(Background, new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y), Color.White);
			spriteBatch.End();
		}

		public void DrawBlocks(SpriteBatch spriteBatch)
		{
			foreach (IBlock block in Blocks)
			{
				block.Draw(spriteBatch, Position);
			}
		}

		public void DrawNPCS(SpriteBatch spriteBatch)
		{
			foreach (INPC npc in NPCs)
			{
				npc.Draw(spriteBatch, Position);
			}
		}

		public void DrawEnemies(SpriteBatch spriteBatch)
		{
			foreach (IEnemy enemy in Enemies)
			{
				enemy.Draw(spriteBatch, Position);
			}
		}

		public void DrawItems(SpriteBatch spriteBatch)
		{
			foreach (IItem item in Items)
			{
				item.Draw(spriteBatch, Position);
			}
		}

		public void DrawDoors(SpriteBatch spriteBatch)
		{
			foreach (IDoor door in Doors)
			{
				door.Draw(spriteBatch, Position);
			}
		}

		public void DrawWalls(SpriteBatch spriteBatch)
		{
			foreach (IWall wall in Walls)
			{
				wall.Draw(spriteBatch, Position);
			}
		}

		public void DrawDialogue(SpriteBatch spriteBatch)
        {
			spriteBatch.Begin();
			spriteBatch.DrawString(mygame.font, Dialogue, new Vector2(size.X/3,size.Y/2), Color.White);
			spriteBatch.End();
		}

	}
}
