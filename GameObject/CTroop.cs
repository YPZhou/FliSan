using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CTroop
    {
        private List<CCharacter> characters_;
        private int maxCombatSkill_;
        private int maxLeaderShip_;
        private int maxStratagem_;
        private CFaction faction_;
        private int soldier_;
        private int injuredSoldier_;
        private int morale_;

        private static Random rand_ = new Random();

        public CTroop(List<CCharacter> _characters, CFaction _faction, int _soldier)
        {
            this.characters_ = _characters;

            this.maxCombatSkill_ = 0;
            this.maxLeaderShip_ = 0;
            this.maxStratagem_ = 0;
            foreach (CCharacter character in this.characters_)
            {
                if (character.CombatSkill > this.maxCombatSkill_)
                {
                    this.maxCombatSkill_ = character.CombatSkill;
                }
                if (character.LeaderShip > this.maxLeaderShip_)
                {
                    this.maxLeaderShip_ = character.LeaderShip;
                }
                if (character.Stratagem > this.maxStratagem_)
                {
                    this.maxStratagem_ = character.Stratagem;
                }
            }

            this.faction_ = _faction;
            this.soldier_ = _soldier;
            this.injuredSoldier_ = 0;
            this.morale_ = 100;
        }

        public int GetDamage(int _soldierInTotal, int _enemySoldierInTotal)
        {
            double soldierFactor = Math.Min(this.soldier_ / 100.0f * (0.5f + _soldierInTotal / _enemySoldierInTotal / 3.0), this.soldier_ / 10.0);
            double characterFactor = 1 + (this.maxCombatSkill_ - 8) / 24.0;
            return (int)Math.Ceiling(soldierFactor * characterFactor);
        }

        public int GetMoraleDamage()
        {
            return (int)Math.Ceiling((1 + (this.maxStratagem_ - 8) / 24.0));
        }

        public void ApplyDamage(int _damage)
        {
            double characterFactor = 1 - (this.maxLeaderShip_ - 8) / 24.0;
            int soldierLoss = Math.Min((int)Math.Ceiling(_damage * characterFactor), this.soldier_);
            int soldierInjured = (int)Math.Ceiling(soldierLoss * (this.morale_ / 160.0f));
            this.soldier_ -= soldierLoss;
            this.injuredSoldier_ += soldierInjured;

            if (this.soldier_ == 0)
            {
                foreach (CCharacter character in this.characters_)
                {
                    double characterDeathRate = (21 - character.CombatSkill) / 80.0;
                    if (CTroop.rand_.NextDouble() < characterDeathRate)
                    {
                        character.IsDead = true;
                    }
                }
            }
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            double characterFactor = 1 - (this.maxStratagem_ - 8) / 24.0;
            int moraleLoss = Math.Min((int)Math.Ceiling(_moraleDamage * characterFactor), this.morale_);
            this.morale_ -= moraleLoss;

            if (this.morale_ == 0)
            {
                foreach (CCharacter character in this.characters_)
                {
                    double characterDeathRate = (21 - character.CombatSkill) / 160.0;
                    if (CTroop.rand_.NextDouble() < characterDeathRate)
                    {
                        character.IsDead = true;
                    }
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CCharacter character in this.characters_)
            {
                sb.Append(character.ToString());
                sb.AppendLine();
            }            
            if (this.IsDefeated)
            {
                sb.Append("部队溃败");
            }
            else
            {
                sb.Append("士兵\t" + this.soldier_ + "\t士气\t" + this.morale_ + "\t伤兵\t" + this.injuredSoldier_);
            }
            return sb.ToString();
        }

        public bool IsDefeated
        {
            get
            {
                return this.soldier_ <= 0 || this.morale_ <= 0;
            }
        }

        public IEnumerator<CCharacter> Character
        {
            get
            {
                return this.characters_.GetEnumerator();
            }
        }

        public CFaction Faction
        {
            get
            {
                return this.faction_;
            }
        }

        public int Soldier
        {
            get
            {
                return this.soldier_;
            }
        }

        public int InjuredSoldier
        {
            get
            {
                return this.injuredSoldier_;
            }
        }

        public int Morale
        {
            get
            {
                return this.morale_;
            }
        }        
    }
}