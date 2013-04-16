using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CGame
    {
        private List<CFaction> factions_;
        private List<CCity> cities_;
        private List<CCharacter> characters_;

        public CGame()
        {
            factions_ = new List<CFaction>();
            cities_ = new List<CCity>();
            characters_ = new List<CCharacter>();
        }
    }
}
