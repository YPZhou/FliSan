using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;

using FliSan.GameObject;

namespace FliSan.GameUI
{
    interface IGameUI
    {
        void Update(CGame _game);
        void Render(RenderWindow _window);
    }
}
