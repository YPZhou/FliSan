using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;
using FliSan.GameObject.GameCommands;

namespace FliSan.GameAI
{
    class CGameAIRandom : IGameAI
    {
        private Random rand_;

        public CGameAIRandom()
        {
            this.rand_ = new Random();
        }

        public void GenerateCommands(CGame _game, Dictionary<int, List<IGameCommand>> _cityGameCommands, int _cityID)
        {
            CCity city = _game.GetCityByID(_cityID);
            if (!_cityGameCommands.ContainsKey(_cityID))
            {
                _cityGameCommands.Add(_cityID, new List<IGameCommand>());
            }

            if (this.rand_.Next(10) < 5)
            {
                IGameCommand gameCmdAttack = new CGameCmdAttack();

                // to implement ...
                // 1. randomly pick characters
                // 2. randomly pick soldier number for each troop
                // 3.1 randomly pick target city and generate defending army
                // 3.2 wait for player input and get defending army

                _cityGameCommands[_cityID].Add(gameCmdAttack);
            }

            foreach (CCharacter character in city.Characters)
            {
                int cmd = this.rand_.Next(4);
                switch (cmd)
                {
                    case 0:
                        _cityGameCommands[_cityID].Add(new CGameCmdDevelopAgriculture(character.City, character, 100));
                        break;
                    case 1:
                        _cityGameCommands[_cityID].Add(new CGameCmdDevelopCommerce(character.City, character, 100));
                        break;
                    case 2:
                        _cityGameCommands[_cityID].Add(new CGameCmdIncreaseCityDefence(character.City, character, 100));
                        break;
                    case 3:
                        _cityGameCommands[_cityID].Add(new CGameCmdRaiseTroop(character.City, character, 100));
                        break;
                }
            }
        }
    }
}
