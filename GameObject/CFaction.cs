using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CFaction
    {
        private List<CCity> cities_;
        private List<CCharacter> characters_;

        private int gold_;
        private int food_;

        public CFaction(int _gold, int _food)
        {
            this.gold_ = _gold;
            this.food_ = _food;
        }
    }
}
