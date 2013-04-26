using System;
using System.Collections.Generic;
using System.Linq;
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
            if (this.isSieging_)
            {
                SiegeUpdate();
            }
            else
            {
                NonSiegeUpdate();
            }
        }

        private void SiegeUpdate()
        {
            if (this.armies_.Count > 1)
            {
                if (this.armies_[0].IsAttacking)
                {
                    int dmg1 = this.armies_[0].GetDamage(this.armies_[1].SoldierInTotal);
                    int dmg2 = this.armies_[1].GetCityDamage(this.armies_[0].SoldierInTotal);

                    int moraleDmg1 = this.armies_[0].GetMoraleDamage();
                    int moraleDmg2 = this.armies_[1].GetCityMoraleDamage();

                    this.armies_[0].ApplyDamage(dmg2);
                    this.armies_[0].ApplyMoraleDamage(moraleDmg2);

                    this.armies_[1].ApplyCityDamage(dmg1);
                    this.armies_[1].ApplyMoraleDamage(moraleDmg1);
                }
                else if (this.armies_[1].IsAttacking)
                {
                    int dmg1 = this.armies_[0].GetCityDamage(this.armies_[1].SoldierInTotal);
                    int dmg2 = this.armies_[1].GetDamage(this.armies_[0].SoldierInTotal);

                    int moraleDmg1 = this.armies_[0].GetCityMoraleDamage();
                    int moraleDmg2 = this.armies_[1].GetMoraleDamage();

                    this.armies_[0].ApplyCityDamage(dmg2);
                    this.armies_[0].ApplyMoraleDamage(moraleDmg2);

                    this.armies_[1].ApplyDamage(dmg1);
                    this.armies_[1].ApplyMoraleDamage(moraleDmg1);
                }
                
            }
        }

        private void NonSiegeUpdate()
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
        }

        public IEnumerator<CArmy> Armies
        {
            get
            {
                return this.armies_.GetEnumerator();
            }
        }

        public bool IsSieging
        {
            get
            {
                return this.isSieging_;
            }
            set
            {
                this.isSieging_ = value;
            }
        }

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

/*
战斗系统
防守方选择迎战或守城

迎战：
防守方失去城防值的保护
攻守双方在平等的状态下进行战斗
防守方迎战失败后，根据双方剩余兵力，进攻方可以直接攻下城池，否则防守方继续守城战
当城池为防守方最后的领地时，必定继续守城战

守城：
利用城防更好地抵挡进攻
农业及商业发展度会降低
会造成非士兵人口减少
会造成城防值降低

迎战
双方各派出至少一支军团，每回合双方军团同时对对方造成伤害，士气或兵力率先降为0的军团战斗失败
攻击方失败时，一部分伤兵加入攻击方，剩余伤兵返回出发城市，武将有可能战死，剩余武将返回出发城市，战斗结束
防守方失败时，一部分伤兵加入攻击方，剩余伤兵返回本方城市，武将有可能战死，剩余武将返回本方城市，双方继续进行攻城战

守城
攻击方派出至少一支军团，防守方不需派出军团
当城市防御值大于0时，攻击方每回合对城市防御值(正常)、城市兵力(极小)、城市农业商业发展度(极小)，城市人口(极小)造成伤害，防守方每回合对攻击方军团造成伤害
当城市防御值为0时，攻击方每回合对城市兵力(正常)、城市农业商业发展度(正常)，城市人口(正常)造成伤害，防守方每回合对攻击方军团造成伤害
任何一方的兵力或士气率先降为0则战斗失败
攻击方失败时，一部分伤兵成为俘虏，剩余伤兵返回出发城市，武将有可能战死，剩余武将返回出发城市，战斗结束
防守方失败且势力还有城市时，一部分伤兵加入攻击方，剩余伤兵返回最近的本方城市，武将有可能战死，剩余武将返回最近的本方城市，战斗结束
防守方失败且势力没有城市时，一部分伤兵加入攻击方，剩余伤兵消失，武将有可能战死，剩余武将加入攻击方，战斗结束，防守方游戏失败

伤害计算：

迎战
部队数量修正 = 部队1或2 1， 部队3 1.1， 部队4 1.2， 部队5 1.3
兵力因子 = min((兵力 / 100) × (0.5 + (总兵力 / 防守方总兵力) / 3), 总兵力 / 10)
武力因子 = 1 + (武力 - 8) / 24

伤害 = sum(兵力因子 × 武力因子) × 部队数量修正

统率因子 = 1 - (统率 - 8) / 24

受到伤害 = 伤害 / 部队数量 × 统率因子

伤兵百分比 = 士气 / 200

智力因子 = 1 + (智力 - 8) / 24
士气伤害 = sum(智力因子)

防守智力因子 = 1 - (智力 - 8) / 24
士气减少 = 士气伤害 × 防守智力因子

武将战死几率 = (20 - 武力) / 80

守城
城市防御值 > 0
部队数量修正 = 部队1或2 1， 部队3 1.1， 部队4 1.2， 部队5 1.3
兵力因子 = min((兵力 / 100) × (0.5 + (总兵力 / 防守方总兵力) / 3), 总兵力 / 10)
武力因子 = 1 + (武力 - 8) / 24

伤害 = sum(兵力因子 × 武力因子) × 部队数量修正

政治因子 = 1 - (防守方最高政治 - 8) / 24
防御值伤害 = 伤害 × 政治因子

统率因子 = 1 - (防守方最高统率 - 8) / 24
士兵伤害 = 伤害 / 10 × 统率因子

城市农业商业伤害 = 伤害 / 1000 × 统率因子

城市人口伤害 = 伤害 / 100 × 统率因子

防守伤害 = 兵力因子 × (1 + (防守方最高政治 - 8) / 24)
实际受到伤害 = 防守伤害 / 部队数量 × 统率因子

士气伤害 = 智力因子 × min(3, 守城武将数量)
士气减少 = 士气伤害 × 智力因子

城市防御值 = 0
部队数量修正 = 部队1或2 1， 部队3 1.1， 部队4 1.2， 部队5 1.3
兵力因子 = min((兵力 / 100) × (0.5 + (总兵力 / 防守方总兵力) / 3), 总兵力 / 10)
武力因子 = 1 + (武力 - 8) / 24

伤害 = sum(兵力因子 × 武力因子) × 部队数量修正

统率因子 = 1 - (防守方最高统率 - 8) / 24
士兵伤害 = 伤害 × 统率因子

城市农业商业伤害 = 伤害 / 50 × 统率因子

城市人口伤害 = 伤害 / 5 × 统率因子

智力因子 = 1 + (智力 - 8) / 24
士气伤害 = sum(智力因子)

防守智力因子 = 1 - (防守最高智力 - 8) / 24
士气减少 = 士气伤害 × 防守智力因子

防守伤害 = 兵力因子 × (1 + (防守方最高政治 - 8) / 24)
实际受到伤害 = 防守伤害 / 部队数量 × 统率因子

士气伤害 = 智力因子 × min(3, 守城武将数量)
士气减少 = 士气伤害 × 智力因子
*/