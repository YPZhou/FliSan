using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdAttack : IGameCommand
    {
        private CCity attacker_;
        private CCity target_;
        private CBattle battle_;

        public CGameCmdAttack()
        {
        }

        public void Execute()
        {
            //to implement ...
            // 1. Update this.battle_ until it is ended
            // 2. Update stats for two cities
        }
    }
}
