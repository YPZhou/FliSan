using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;
using FliSan.GameObject.GameCommands;

namespace FliSan.GameAI
{
    interface IGameAI
    {
        void Run(CGame _game, Dictionary<int, List<IGameCommand>> _cityGameCommands);
    }
}
