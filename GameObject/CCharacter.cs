using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CCharacter
    {
        private CFaction faction_;
        private CCity city_;

        private int leaderShip_;
        private int combatSkill_;
        private int stratagem_;
        private int politics_;

        private int origin_;
        private int persona1_;
        private int persona2_;

        private List<int> personaLikes_;
        private List<int> personaHates_;
    }
}
