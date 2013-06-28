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
            foreach (CCharacter character in city.Characters)
            {
                if (!_cityGameCommands.ContainsKey(character.City.ID))
                {
                    _cityGameCommands.Add(character.City.ID, new List<IGameCommand>());
                }
                int cmd = this.rand_.Next(4);
                switch (cmd)
                {
                    case 0:
                        _cityGameCommands[character.City.ID].Add(new CGameCmdDevelopAgriculture(character.City, character, 100));
                        break;
                    case 1:                        
                        _cityGameCommands[character.City.ID].Add(new CGameCmdDevelopCommerce(character.City, character, 100));
                        break;
                    case 2:
                        _cityGameCommands[character.City.ID].Add(new CGameCmdIncreaseCityDefence(character.City, character, 100));
                        break;
                    case 3:
                        _cityGameCommands[character.City.ID].Add(new CGameCmdRaiseTroop(character.City, character, 100));
                        break;
                }
            }
        }
    }
}
