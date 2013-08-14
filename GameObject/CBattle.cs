using System.Collections.Generic;
using System;
using System.Text;

namespace FliSan.GameObject
{
    class CBattle
    {
        protected CArmy[] armies_;

        public CBattle()
        {
            this.armies_ = new CArmy[2];
        }

        public void AddArmy1(CArmy _army)
        {
            this.armies_[0] = _army;
        }

        public void AddArmy2(CArmy _army)
        {
            this.armies_[1] = _army;
        }

        public void Update()
        {            
            int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
            int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

            int moraleDmg1 = this.armies_[0].GetMoraleDamage(this.armies_[1].SoldierInTotal);
            int moraleDmg2 = this.armies_[1].GetMoraleDamage(this.armies_[0].SoldierInTotal);

            this.armies_[0].ApplyDamage(dmg2);
            this.armies_[0].ApplyMoraleDamage(moraleDmg2);

            this.armies_[1].ApplyDamage(dmg1);
            this.armies_[1].ApplyMoraleDamage(moraleDmg1);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("军队 1 ");
            sb.AppendLine();
            sb.Append(this.armies_[0].ToString());
            sb.AppendLine();

            sb.Append("军队 2 ");
            sb.AppendLine();
            sb.Append(this.armies_[1].ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        public CArmy[] Armies
        {
            get
            {
                return this.armies_;
            }
        }

        public bool IsBattleEnd
        {
            get
            {
                if (this.armies_.Length < 2)
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