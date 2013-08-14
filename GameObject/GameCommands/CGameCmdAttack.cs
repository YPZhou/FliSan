using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameAI;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdAttack : IGameCommand
    {
        //private CCity attacker_;
        private int targetCityID_;
        private CBattle battle_;

        public CGameCmdAttack(int _targetCityID, CBattle _battle)
        {
            this.targetCityID_ = _targetCityID;
            this.battle_ = _battle;
        }

        public void Execute(CGameAIManager _gameAIManager)
        {            
            CArmy defendingArmy = _gameAIManager.GetDefendingArmy(this.targetCityID_, this.battle_.Armies[0]);
            this.battle_.AddArmy2(defendingArmy);

            //to implement ...
            // 1. Update this.battle_ until it is ended
            // 2. Update stats for two cities

            while (!this.battle_.IsBattleEnd)
            {
            }
        }
    }
}
