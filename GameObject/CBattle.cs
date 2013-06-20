using System.Collections.Generic;
using System;
using System.Text;

namespace FliSan.GameObject
{
    class CBattle
    {
        private List<CArmy> armies_;
        private bool isSieging_;

        public CBattle()
        {
            this.armies_ = new List<CArmy>();
        }

        public void AddArmy(CArmy _army)
        {
            if (_army != null)
            {
                this.armies_.Add(_army);
            }
        }

        public void Update()
        {
            if (this.armies_.Count > 1)
            {
                int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
                int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

                int moraleDmg1 = this.armies_[0].GetMoraleDamage();
                int moraleDmg2 = this.armies_[1].GetMoraleDamage();

                this.armies_[0].ApplyDamage(dmg2);
                this.armies_[0].ApplyMoraleDamage(moraleDmg2);

                this.armies_[1].ApplyDamage(dmg1);
                this.armies_[1].ApplyMoraleDamage(moraleDmg1);
            }

            //if (this.isSieging_)
            //{
            //    SiegeUpdate();
            //}
            //else
            //{
            //    NonSiegeUpdate();
            //}

            //foreach (CArmy army in this.armies_)
            //{
            //    army.ConsumeFood();
            //    army.SoldierFlee();
            //}
        }

        //private void SiegeUpdate()
        //{
        //    if (this.armies_.Count > 1)
        //    {
        //        if (this.armies_[0].IsAttacking)
        //        {
        //            int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
        //            int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

        //            int moraleDmg1 = this.armies_[0].GetMoraleDamage();
        //            int moraleDmg2 = this.armies_[1].GetMoraleDamage();

        //            this.armies_[0].ApplyDamage(dmg2);
        //            this.armies_[0].ApplyMoraleDamage(moraleDmg2);                    

        //            if (!this.armies_[1].IsCityDefenceBroken)
        //            {
        //                this.armies_[1].ApplyDamage(dmg1);
        //            }
        //            else
        //            {
        //                this.armies_[1].ApplyCityDamage(dmg1);
        //                this.armies_[1].ApplyDamage(dmg1);
        //                this.armies_[1].ApplyMoraleDamage(moraleDmg1);
        //            }
        //        }
        //        else if (this.armies_[1].IsAttacking)
        //        {
        //            int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
        //            int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

        //            int moraleDmg1 = this.armies_[0].GetMoraleDamage();
        //            int moraleDmg2 = this.armies_[1].GetMoraleDamage();

        //            this.armies_[1].ApplyDamage(dmg1);
        //            this.armies_[1].ApplyMoraleDamage(moraleDmg1);                    

        //            if (!this.armies_[0].IsCityDefenceBroken)
        //            {
        //                this.armies_[0].ApplyDamage(dmg2);
        //            }
        //            else
        //            {
        //                this.armies_[0].ApplyCityDamage(dmg2);
        //                this.armies_[0].ApplyDamage(dmg2);
        //                this.armies_[0].ApplyMoraleDamage(moraleDmg2);
        //            }
        //        }
                
        //    }
        //}

        //private void NonSiegeUpdate()
        //{
        //    if (this.armies_.Count > 1)
        //    {
        //        int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
        //        int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

        //        int moraleDmg1 = this.armies_[0].GetMoraleDamage();
        //        int moraleDmg2 = this.armies_[1].GetMoraleDamage();

        //        this.armies_[0].ApplyDamage(dmg2);
        //        this.armies_[0].ApplyMoraleDamage(moraleDmg2);

        //        this.armies_[1].ApplyDamage(dmg1);
        //        this.armies_[1].ApplyMoraleDamage(moraleDmg1);
        //    }
        //}

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.armies_.Count; i++)
            {
                sb.Append("军队 " + i);
                sb.AppendLine();
                sb.Append(this.armies_[i].ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public IEnumerator<CArmy> Armies
        {
            get
            {
                return this.armies_.GetEnumerator();
            }
        }

        //public bool IsSieging
        //{
        //    get
        //    {
        //        return this.isSieging_;
        //    }
        //    set
        //    {
        //        this.isSieging_ = value;
        //    }
        //}

        public bool IsBattleEnd
        {
            get
            {
                if (this.armies_.Count < 2)
                {
                    return true;
                }
                else
                {
                    return this.armies_[0].IsDefeated || this.armies_[1].IsDefeated;
                }
            }
        }
    }
}