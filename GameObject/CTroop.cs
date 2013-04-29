using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CTroop
    {
        private CCharacter character_;
        private CFaction faction_;
        private int soldier_;
        private int injuredSoldier_;
        private int morale_;

        public CTroop()
        {
            
        }

        public int GetDamage(int _soldierInTotal)
        {
            return 0;
        }

        public int GetMoraleDamage()
        {
            return 0;
        }

        public void ApplyDamage(int _damage)
        {
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
        }

        public CCharacter Character
        {
            get
            {
                return this.character_;
            }
            set
            {
                this.character_ = value;
            }
        }

        public CFaction Faction
        {
            get
            {
                return this.faction_;
            }
            set
            {
                this.faction_ = value;
            }
        }

        public int Soldier
        {
            get
            {
                return this.soldier_;
            }
            set
            {
                this.soldier_ = value;
            }
        }

        public int InjuredSoldier
        {
            get
            {
                return this.injuredSoldier_;
            }
            set
            {
                this.injuredSoldier_ = value;
            }
        }

        public int Morale
        {
            get
            {
                return this.morale_;
            }
            set
            {
                this.morale_ = value;
            }
        }        
    }
}