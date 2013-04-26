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
            return 0;
        }

        public int GetMoraleDamage()
        {
            return 0;
        }

        public int GetCityDamage(int _soldierInTotal)
        {
            return 0;
        }

        public int GetCityMoraleDamage()
        {
            return 0;
        }

        public void ApplyDamage(int _damage)
        {
        }

        public void ApplyMoraleDamage(int _damage)
        {
        }

        public void ApplyCityDamage(int _damage)
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
