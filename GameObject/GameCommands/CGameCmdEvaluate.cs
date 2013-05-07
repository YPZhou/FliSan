using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdEvaluate : IGameCommand
    {
        private CCharacter character1_;
        private CCharacter character2_;

        public CGameCmdEvaluate(CCharacter _character1, CCharacter _character2)
        {
            this.character1_ = _character1;
            this.character2_ = _character2;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
