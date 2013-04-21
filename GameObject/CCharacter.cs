﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CCharacter
    {
        private int ID_;

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

        public CCharacter(int _ID, CFaction _faction, CCity _city)
        {
            this.ID_ = _ID;
            this.faction_ = _faction;
            this.city_ = _city;

            this.personaLikes_ = new List<int>();
            this.personaHates_ = new List<int>();
        }

        public override bool Equals(Object _that)
        {
            if (_that is CCharacter)
            {
                return this.ID_ == ((CCharacter)_that).ID_;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID_;
        }
    }
}
