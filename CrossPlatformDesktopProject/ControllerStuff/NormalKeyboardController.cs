using CrossPlatformDesktopProject.CommandStuff;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0
{
    class NormalKeyboardController : IController
    {
        private Game1 game;
        private Keys[] prevPressedKeys = new Keys[0];
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<Keys, ICommand> moveMappings;
        private Dictionary<List<Keys>, int> cheatCodePositions;
        private Dictionary<List<Keys>, ICommand> cheatCommands;
        private int wait = 1;


        public NormalKeyboardController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            
            cheatCommands = new Dictionary<List<Keys>, ICommand>() {
                {new List<Keys>() {Keys.Up,Keys.Down,Keys.Up,Keys.Down }, new CommandLightsOn(game) }
            };
            cheatCodePositions = new Dictionary<List<Keys>, int>();
            foreach (KeyValuePair<List<Keys>, ICommand> kvp in cheatCommands)
            {
                cheatCodePositions.Add(kvp.Key,0);
            }
            moveMappings = new Dictionary<Keys, ICommand>();

            moveMappings.Add(Keys.W, new CommandMoveUp(game));
            moveMappings.Add(Keys.A, new CommandMoveLeft(game));
            moveMappings.Add(Keys.S, new CommandMoveDown(game));
            moveMappings.Add(Keys.D, new CommandMoveRight(game));
            moveMappings.Add(Keys.Up, new CommandMoveUp(game));
            moveMappings.Add(Keys.Down, new CommandMoveDown(game));
            moveMappings.Add(Keys.Left, new CommandMoveLeft(game));
            moveMappings.Add(Keys.Right, new CommandMoveRight(game));
            RegisterCommand(Keys.B, new CommandUseItemB(game));
            RegisterCommand(Keys.N, new CommandUseItemN(game));
            RegisterCommand(Keys.E, new CommandDamage(game));
            RegisterCommand(Keys.C, new CommandShowColliders(game));
            RegisterCommand(Keys.V, new CommandRemoveColliders(game));
            RegisterCommand(Keys.G, new CommandSpawnItem(game));
            RegisterCommand(Keys.Escape, new CommandPause(game));
            RegisterCommand(Keys.I, new CommandOpenInventory(game));
            RegisterCommand(Keys.R, new CommandReset(game));
            RegisterCommand(Keys.Q, new CommandQuit(game));
            RegisterCommand(Keys.M, new CommandMute());
            RegisterCommand(Keys.L, new CommandLightsOn(game));
            RegisterCommand(Keys.K, new CommandLightsOff(game));
            RegisterCommand(Keys.P, new CommandEnablePartyLights(game));
            RegisterCommand(Keys.O, new CommandDisablePartyLights(game));
            RegisterCommand(Keys.F5, new CommandSaveGame(game));
            RegisterCommand(Keys.F9, new CommandLoadGame(game));
            
        }

        private void CheckCheatCodes(Keys[] pressedKeys)
        {
            List<List<Keys>> cheatIncement = new List<List<Keys>>();
            List<List<Keys>> cheatSetZero = new List<List<Keys>>();

            foreach (List<Keys> cheatCode in cheatCodePositions.Keys)
            {
                if (pressedKeys.Contains(cheatCode[cheatCodePositions[cheatCode]]) && !prevPressedKeys.Contains(cheatCode[cheatCodePositions[cheatCode]]))
                {
                    cheatIncement.Add(cheatCode);
                }
                else if (!(pressedKeys.Contains(cheatCode[cheatCodePositions[cheatCode]]) && 
                    !prevPressedKeys.Contains(cheatCode[cheatCodePositions[cheatCode]]))
                    && pressedKeys.Length > 0 && prevPressedKeys.Length == 0)
                {
                    cheatSetZero.Add(cheatCode);
                }
            }
            for (int i = 0; i < cheatIncement.Count; i++)
            {
                List<Keys> cheatCode = cheatIncement[i];
                cheatCodePositions[cheatCode]++;
                if (cheatCodePositions[cheatCode] == cheatCode.Count)
                {
                    cheatCodePositions[cheatCode] = 0;
                    cheatCommands[cheatCode].Execute();
                }
            }
            for(int i = 0; i < cheatSetZero.Count; i++)
            {
                    cheatCodePositions[cheatSetZero[i]] = 0;
                
            }
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            CheckCheatCodes(pressedKeys);   
            if (wait <= 0)
            {
                if (prevPressedKeys.Contains(Keys.W) || prevPressedKeys.Contains(Keys.A) || prevPressedKeys.Contains(Keys.S) || prevPressedKeys.Contains(Keys.D))
                {
                    if (!pressedKeys.Contains(Keys.W) && !pressedKeys.Contains(Keys.A) && !pressedKeys.Contains(Keys.S) && !pressedKeys.Contains(Keys.D))
                    {
                        game.player.StopMoving();
                    }
                }
                if (prevPressedKeys.Contains(Keys.Up) || prevPressedKeys.Contains(Keys.Down) || prevPressedKeys.Contains(Keys.Left) || prevPressedKeys.Contains(Keys.Right))
                {
                    if (!pressedKeys.Contains(Keys.Up) && !pressedKeys.Contains(Keys.Down) && !pressedKeys.Contains(Keys.Left) && !pressedKeys.Contains(Keys.Right))
                    {
                        game.player.StopMoving();
                    }
                }

                if (!prevPressedKeys.Contains(Keys.LeftShift) && pressedKeys.Contains(Keys.LeftShift))
                {
                    game.reversingTime = true;
                }
                if (prevPressedKeys.Contains(Keys.LeftShift) && !pressedKeys.Contains(Keys.LeftShift))
                {
                    game.reversingTime = false;
                }

                bool doneMovement = false;
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key) && !prevPressedKeys.Contains(key))
                    {
                        controllerMappings[key].Execute();
                    }
                    if (moveMappings.ContainsKey(key) && !doneMovement)
                    {
                        moveMappings[key].Execute();
                        doneMovement = true;
                    }
                }
            }
            else
            {
                wait--;
                game.player.StopMoving();
            }

            prevPressedKeys = pressedKeys;
        }
    }
}
