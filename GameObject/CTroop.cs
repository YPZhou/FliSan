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

        public int GetDamage(int _soldierInTotal, int _enemySoldierInTotal)
        {
            float soldierFactor = Math.Min(this.soldier_ / 100.0f * (0.5f + _soldierInTotal / (float)_enemySoldierInTotal / 3.0f), this.soldier_ / 10.0f);
            float characterFactor = 1 + (this.character_.CombatSkill - 8) / 24.0f;
            return (int)(soldierFactor * characterFactor);
        }

        public int GetMoraleDamage()
        {
            return (int)(1 + (this.character_.Stratagem - 8) / 24.0f);
        }

        public void ApplyDamage(int _damage)
        {
            float characterFactor = 1 - (this.character_.LeaderShip - 8) / 24.0f;
            int soldierLoss = Math.Min((int)(_damage * characterFactor), this.soldier_);
            int soldierInjured = (int)(soldierLoss * (this.morale_ / 200.0f));
            this.soldier_ -= soldierLoss;
            this.injuredSoldier_ += soldierInjured;
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            float characterFactor = 1 - (this.character_.Stratagem - 8) / 24.0f;
            int moraleLoss = Math.Min((int)(_moraleDamage * characterFactor), this.morale_);
            this.morale_ -= moraleLoss;
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