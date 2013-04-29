using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CCity
    {
        private int ID_;

        private CFaction faction_;
        private List<CCharacter> characters_;
        private int mapCoordX_;
        private int mapCoordY_;

        private int maxAgriculturePopulation_;

        private int population_;
        private int gold_;
        private int food_;
        private int populationLoseCounter_;
        private int populationGainCounter_;

        private double foodIncRate_;
        private double foodConsumpRate_;
        private double goldIncRate_;

        private int cityDefence_;
        private int soldier_;
        private int morale_;

        public CCity(int _ID, CFaction _faction)
        {
            this.ID_ = _ID;
            this.faction_ = _faction;
            this.characters_ = new List<CCharacter>();
            this.mapCoordX_ = -1;
            this.mapCoordY_ = -1;
            this.populationLoseCounter_ = 1;
            this.populationGainCounter_ = 1;
        }

        public void Update(int _gameTurn)
        {
            // food updates
            int foodConsumption = (int)Math.Floor(this.population_ * this.foodConsumpRate_);
            int foodIncrease = 0;
            if (_gameTurn % 180 == 0)
            {
                int workingPopulation = this.population_ - this.soldier_;
                if (workingPopulation > this.maxAgriculturePopulation_)
                {
                    workingPopulation = this.maxAgriculturePopulation_;
                }
                foodIncrease = (int)Math.Floor(workingPopulation * this.foodIncRate_);
            }
            this.food_ += foodIncrease - foodConsumption;
            if (this.food_ < 0)
            {
                this.food_ = 0;
            }

            // population increases as long as city has food remaining,
            // and decreases once city runs out of food
            if (this.food_ > 0)
            {
                // population increase
                this.populationLoseCounter_ = 1; // reset populationLoseCounter
                if (this.populationGainCounter_ < int.MaxValue - this.population_)
                {
                    this.population_ += this.populationGainCounter_;
                }
                this.populationGainCounter_++;
            }
            else
            {
                // population decrease
                this.populationGainCounter_ = 1; // reset populationGainCounter
                if (this.population_ > 0)
                {
                    this.population_ -= this.populationLoseCounter_;
                    if (this.soldier_ > 0)
                    {
                        this.soldier_ -= this.populationLoseCounter_;
                        if (this.soldier_ < 0)
                        {
                            this.soldier_ = 0;
                        }
                    }
                    if (this.population_ < 0)
                    {
                        this.population_ = 0;
                    }

                    this.populationLoseCounter_++;
                }
            }

            // gold updates
            int goldIncrease = 0;
            if (_gameTurn % 30 == 0)
            {
                if (this.food_ > 0)
                {
                    goldIncrease = (int)Math.Floor(this.food_ * this.goldIncRate_);
                }
            }
            this.gold_ += goldIncrease;
        }

        public void AddCharacter(CCharacter _character)
        {
            bool canAddCharacter = true;
            foreach (CCharacter character in this.characters_)
            {
                if (character.Equals(_character))
                {
                    canAddCharacter = false;
                }
            }

            if (canAddCharacter)
            {
                this.characters_.Add(_character);
            }
        }

        public int GetCityDamage(int _soldierInTotal, int _enemySoldierInTotal)
        {
            return 0;
        }

        public int GetCityMoraleDamage()
        {
            return 0;
        }

        public void ApplyCityDamage(int _damage)
        {
            // need to complete rules for city development first
        }

        public void ApplyCityMoraleDamage(int _moraleDamage)
        {
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

        public int MapCoordX
        {
            get
            {
                return this.mapCoordX_;
            }
            set
            {
                this.mapCoordX_ = value;
            }
        }

        public int MapCoordY
        {
            get
            {
                return this.mapCoordY_;
            }
            set
            {
                this.mapCoordY_ = value;
            }
        }

        public int Food
        {
            get
            {
                return this.food_;
            }
            set
            {
                this.food_ = value;
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

        public bool IsCityDefenceBroken
        {
            get
            {
                return this.cityDefence_ <= 0;
            }
        }

        public override bool Equals(Object _that)
        {
            if (_that is CCity)
            {
                return this.ID_ == ((CCity)_that).ID_;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID_;
        }
    }
}

/*
内政系统

属性：
人口				领地的住民数量，影响粮食产量，金钱收入，以及最大士兵数。领地发生饥荒时人口减少，否则人口增加。（单位人口粮食产量最低为1.5，人均粮食消耗为每回合0.1）
粮食产量			由农业开发度决定单位人口的粮食产量，领地的耕地面积（领地固有属性）决定最大农业劳动人口。
贸易收入			由商业开发度决定单位粮食的贸易收入，贸易收入没有上限，只受人民剩余粮食影响。（单位粮食金钱收入最低为1）

收入：
粮食				每6回合增加一次，增加量为生产人口×单位人口粮食产量
金钱				每回合增加一次，增加量为(生产人口×单位人口粮食产量/6-该回合粮食消耗)×单位粮食金钱收入

秋季单位人口粮食产量×2 18回合，3次粮食增加
冬季单位粮食金钱收入×2 18回合，18次金钱增加

人口减少			每回合检查，减少量为不足的粮食量/1.5，优先减少士兵
人口增加			每6回合检查，增加量为非战斗人口的百分之一×单位人口粮食产量/1.5

指令：
发展农业			消耗100金钱，增加最低0.01的单位人口粮食产量（具体增加量由实行武将的属性决定）
发展商业			消耗100金钱，增加最低0.01的单位粮食贸易收入（具体增加量由实行武将的属性决定）
征集士兵			消耗最多2金钱/士兵，将人口变为士兵，士兵不参与农业生产，但仍会消耗粮食（具体金钱消耗由实行武将的属性决定） （长期战争会导致人口急剧减少）
修补城池			消耗金钱，增加城防值（具体增加量由实行武将属性决定）
*/