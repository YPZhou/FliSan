using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameAI;

namespace FliSan.GameObject.GameCommands
{
    interface IGameCommand
    {
        void Execute(CGameAIManager _gameAIManager);
    }
}
