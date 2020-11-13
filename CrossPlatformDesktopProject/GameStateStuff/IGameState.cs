﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStateStuff
{
    public interface IGameState
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}