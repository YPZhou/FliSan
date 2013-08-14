using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CArmy
    {
        private List<CTroop> troops_;
        private int troopCount_;
        private CFaction faction_;
        private CCity city_;
        private int status_;            // 0 normal 1 sieging 2 defending

        public CArmy(List<CTroop> _troops, CCity _city, int _status)
        {
            this.troops_ = _troops;
            this.troopCount_ = this.troops_.Count;
            this.faction_ = this.troops_[0].Faction;
            this.city_ = _city;
            this.status_ = _status;
        }

        public int GetDamage(int _enemySoldierInTotal)
        {
            float troopCountFacter = Math.Max(0, this.troopCount_) * 0.1f + 1;
            int damage = 0;
            foreach (CTroop troop in this.troops_)
            {
                if (!troop.IsDefeated)
                {
                    damage += troop.GetDamage(this.SoldierInTotal, _enemySoldierInTotal);
                }
            }
            return (int)(damage * troopCountFacter);
        }

        public int GetMoraleDamage(int _enemySoldierInTotal)
        {
            int moraleDamage = 0;
            foreach (CTroop troop in this.troops_)
            {
                if (!troop.IsDefeated)
                {
                    moraleDamage += troop.GetMoraleDamage();
                }
            }
            double soldierFactor = (_enemySoldierInTotal - this.SoldierInTotal) / (double)_enemySoldierInTotal / 3.0;
            return (int)Math.Ceiling(moraleDamage * (1 - soldierFactor));
        }

        public void ApplyDamage(int _damage)
        {
            int damage = (int)Math.Ceiling(_damage / (double)this.troopCount_);
            if (this.status_ == 2)
            {
                if (this.city_.CityDefence > 0)
                {
                    damage = (int)Math.Ceiling(damage / 10.0);
                }
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyDamage(damage);
                        if (troop.IsDefeated)
                        {
                            this.troopCount_--;
                        }
                    }
                }
                this.city_.ApplyCityDamage(damage);
            }
            else
            {
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyDamage(damage);
                        if (troop.IsDefeated)
                        {
                            this.troopCount_--;
                        }
                    }
                }
            }
            
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            int damage = (int)Math.Ceiling(_moraleDamage / (double)this.troopCount_);
            if (this.status_ != 2 || (this.status_ == 2 && this.city_.CityDefence <= 0))
            {
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyMoraleDamage(_moraleDamage);
                        if (troop.IsDefeated)
                        {
                            this.troopCount_--;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("城防\t" + this.city_.CityDefence + "\t人口\t" + this.city_.Population + "\t粮食收入\t" + this.city_.FoodIncreaseRate + "\t金钱收入\t" + this.city_.GoldIncreaseRate);
            for (int i = 0; i < this.troops_.Count; i++)
            {                
                sb.Append("部队 " + i);
                sb.AppendLine();
                sb.Append(this.troops_[i].ToString());
                sb.AppendLine();
            }
            return sb.ToString();
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
        }

        public CCity City
        {
            get
            {
                return this.city_;
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

        public int Status
        {
            get
            {
                return this.status_;
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
