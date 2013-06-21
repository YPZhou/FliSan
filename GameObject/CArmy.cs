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
        //private bool isAttacking_;
        private int status_;            // 0 normal 1 sieging 2 defending

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

        public int GetDamage(int _enemySoldierInTotal)
        {
            int defeatedTroopCount = 0;
            foreach (CTroop troop in this.troops_)
            {
                if (troop.IsDefeated)
                {
                    defeatedTroopCount++;
                }
            }
            float troopCountFacter = 1;
            if (this.troops_.Count - defeatedTroopCount == 5)
            {
                troopCountFacter = 1.3f;
            }
            else if (troops_.Count - defeatedTroopCount == 4)
            {
                troopCountFacter = 1.2f;
            }
            else if (troops_.Count - defeatedTroopCount == 3)
            {
                troopCountFacter = 1.1f;
            }
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

        //public int GetCityDamage(int _enemySoldierInTotal)
        //{
        //    return this.city_.GetCityDamage(_enemySoldierInTotal);
        //}

        //public int GetCityMoraleDamage()
        //{
        //    return this.city_.GetCityMoraleDamage();
        //}

        public void ApplyDamage(int _damage)
        {
            int damage = (int)Math.Ceiling(_damage / (float)this.troops_.Count);
            if (this.status_ == 2 && this.city_.CityDefence > 0)
            {
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyDamage((int)Math.Ceiling(damage / 10.0));
                    }
                }
                this.city_.ApplyCityDamage(damage);
            }
            else if (this.status_ == 2)
            {
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyDamage(damage);
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
                    }
                }
            }
            
        }

        public void ApplyMoraleDamage(int _moraleDamage)
        {
            int damage = (int)Math.Ceiling(_moraleDamage / (double)this.troops_.Count);
            if (this.status_ != 2 || (this.status_ == 2 && this.city_.CityDefence <= 0))
            {
                foreach (CTroop troop in this.troops_)
                {
                    if (!troop.IsDefeated)
                    {
                        troop.ApplyMoraleDamage(_moraleDamage);
                    }
                }
            }
        }

        public void ApplyCityDamage(int _damage)
        {
            this.city_.ApplyCityDamage(_damage);
        }

        //public void ApplyCityMoraleDamage(int _moraleDamage)
        //{
        //    this.city_.ApplyCityMoraleDamage(_moraleDamage);
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("城防\t" + this.city_.CityDefence + "\t士气\t" + this.city_.Morale + "\t人口\t" + this.city_.Population + "\t粮食收入\t" + this.city_.FoodIncreaseRate + "\t金钱收入\t" + this.city_.GoldIncreaseRate);
            for (int i = 0; i < this.troops_.Count; i++)
            {                
                sb.Append("部队 " + i);
                sb.AppendLine();
                sb.Append(this.troops_[i].ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        //public void ConsumeFood()
        //{
        //    // need to complete rules for food consumption first
        //}

        //public void SoldierFlee()
        //{
        //    // need to complete rules for soldier flee first
        //}

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

        //public bool IsAttacking
        //{
        //    get
        //    {
        //        return this.isAttacking_;
        //    }
        //    set
        //    {
        //        this.isAttacking_ = value;
        //    }
        //}

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

        //public bool IsCityDefenceBroken
        //{
        //    get
        //    {
        //        return this.city_.CityDefence <= 0;
        //    }
        //}

        public int Status
        {
            get
            {
                return this.status_;
            }
            set
            {
                this.status_ = value;
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
