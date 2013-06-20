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
            double soldierFactor = Math.Min(this.soldier_ / 100.0f * (0.5f + _soldierInTotal / _enemySoldierInTotal / 3.0), this.soldier_ / 10.0);
            double characterFactor = 1 + (this.character_.CombatSkill - 8) / 24.0;
            return (int)Math.Ceiling(soldierFactor * characterFactor);
        }

        public int GetMoraleDamage()
        {
            return (int)(1 + (this.character_.Stratagem - 8) / 24.0);
        }

        public void ApplyDamage(int _damage)
        {
            double characterFactor = 1 - (this.character_.LeaderShip - 8) / 24.0;
            int soldierLoss = Math.Min((int)Math.Ceiling(_damage * characterFactor), this.soldier_);
            int soldierInjured = (int)Math.Ceiling(soldierLoss * (this.morale_ / 160.0f));
            this.soldier_ -= soldierLoss;
            this.injuredSoldier_ += soldierInjured;
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            double characterFactor = 1 - (this.character_.Stratagem - 8) / 24.0;
            int moraleLoss = Math.Min((int)Math.Ceiling(_moraleDamage * characterFactor), this.morale_);
            this.morale_ -= moraleLoss;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.character_.ToString());
            sb.Append("士兵\t" + this.soldier_ + "\t士气\t" + this.morale_ + "\t伤兵\t" + this.injuredSoldier_);
            return sb.ToString();
        }

        public bool IsDefeated
        {
            get
            {
                return this.soldier_ <= 0 || this.morale_ <= 0;
            }
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