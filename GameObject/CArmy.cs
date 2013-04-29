using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CArmy
    {
        private List<CTroop> troops_;
        private CFaction faction_;
        private CCity city_;
        private bool isAttacking_;

        public CArmy()
        {
            this.troops_ = new List<CTroop>();
        }

        public void AddTroop(CTroop _troop)
        {
            if (_troop != null)
            {
                this.troops_.Add(_troop);
            }
        }

        public int GetDamage(int _soldierInTotal)
        {
            float troopCountFacter = 1;
            if (this.troops_.Count == 5)
            {
                troopCountFacter = 1.3f;
            }
            else if (troops_.Count == 4)
            {
                troopCountFacter = 1.2f;
            }
            else if (troops_.Count == 3)
            {
                troopCountFacter = 1.1f;
            }
            int damage = 0;
            foreach (CTroop troop in this.troops_)
            {
                damage += troop.GetDamage(_soldierInTotal);
            }
            return (int)(damage * troopCountFacter);
        }

        public int GetMoraleDamage()
        {
            int moraleDamage = 0;
            foreach (CTroop troop in this.troops_)
            {
                moraleDamage += troop.GetMoraleDamage();
            }
            return moraleDamage;
        }

        public int GetCityDamage(int _soldierInTotal)
        {
            return this.city_.GetCityDamage(_soldierInTotal);
        }

        public int GetCityMoraleDamage()
        {
            return this.city_.GetCityMoraleDamage();
        }

        public void ApplyDamage(int _damage)
        {
            int damage = (int)Math.Ceiling(_damage / (float)this.troops_.Count);
            foreach (CTroop troop in this.troops_)
            {
                troop.ApplyDamage(damage);
            }
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            foreach (CTroop troop in this.troops_)
            {
                troop.ApplyMoraleDamage(_moraleDamage);
            }
        }

        public void ApplyCityDamage(int _damage)
        {
            this.city_.ApplyCityDamage(_damage);
        }

        public void ApplyCityMoraleDamage(int _moraleDamage)
        {
            this.city_.ApplyCityMoraleDamage(_moraleDamage);
        }

        public void ConsumeFood()
        {
        }

        public IEnumerator<CTroop> Troops
        {
            get
            {
                return this.troops_.GetEnumerator();
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

        public CCity City
        {
            get
            {
                return this.city_;
            }
            set
            {
                this.city_ = value;
            }
        }

        public bool IsAttacking
        {
            get
            {
                return this.isAttacking_;
            }
            set
            {
                this.isAttacking_ = value;
            }
        }

        public bool IsDefeated
        {
            get
            {
                if (this.troops_.Count > 0)
                {
                    bool armyDefeated = true;
                    foreach (CTroop troop in this.troops_)
                    {
                        if (troop.Morale > 0 && troop.Soldier > 0)
                        {
                            armyDefeated = false;
                        }
                    }
                    return armyDefeated;
                }
                else
                {
                    return this.city_.Soldier > 0;
                }
            }
        }

        public bool IsCityDefenceBroken
        {
            get
            {
                return this.IsCityDefenceBroken;
            }
        }

        public int SoldierInTotal
        {
            get
            {
                int soldierInTotal = 0;
                foreach (CTroop troop in this.troops_)
                {
                    if (troop.Morale > 0) soldierInTotal += troop.Soldier;
                }
                return soldierInTotal;
            }
        }
    }
}
