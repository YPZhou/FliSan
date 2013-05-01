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

            this.maxAgriculturePopulation_ = 50000;
            this.population_ = 3000;
            this.gold_ = 1000;
            this.food_ = 5000;
            this.foodIncRate_ = 1.5;
            this.foodConsumpRate_ = 0.1;
            this.goldIncRate_ = 1.0;

            this.cityDefence_ = 1000;
            this.soldier_ = 500;
            this.morale_ = 100;
        }

        public void Update(int _gameTurn)
        {
            // food updates
            int foodConsumption = (int)Math.Floor(this.population_ * this.foodConsumpRate_);
            int foodIncrease = 0;

            // check food increase every month (6 turns)
            if (_gameTurn % 6 == 0)
            {
                // food increase rate is doubled in autumn
                if (_gameTurn % 72 > 36 && _gameTurn % 72 < 55)
                {
                    foodIncrease = (int)Math.Floor(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ * 2);
                }
                else
                {
                    foodIncrease = (int)Math.Floor(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_);
                }
            }
            this.food_ += foodIncrease - foodConsumption;
            int foodShortage = 0;
            if (this.food_ < 0)
            {
                foodShortage = -this.food_;
                this.food_ = 0;
            }

            // population increases as long as city has food remaining,
            // and decreases once city runs out of food
            if (this.food_ > 0)
            {
                // check population increase every month (6 turns)
                if (_gameTurn % 6 == 0)
                {
                    this.population_ += (int)Math.Floor(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ / 150.0);
                }
            }
            else
            {
                // check population decrease every 5 days (1 turn)
                this.population_ = Math.Max(this.population_ - (int)Math.Floor(foodShortage / 1.5), 0);
                this.soldier_ = Math.Max(this.soldier_ - (int)Math.Floor(foodShortage / 1.5), 0);
            }

            // gold updates            
            // check gold increase every 5 days (1 turn)

            // gold increase rate is doubled in winter
            if (_gameTurn % 72 > 54 && _gameTurn % 72 <= 71)
            {
                this.gold_ += (int)Math.Floor(Math.Max(foodIncrease / 6.0 - foodConsumption, 0) * this.goldIncRate_ * 2);
            }
            else
            {
                this.gold_ += (int)Math.Floor(Math.Max(foodIncrease / 6.0 - foodConsumption, 0) * this.goldIncRate_);
            }
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

        public int Gold
        {
            get
            {
                return this.gold_;
            }
            set
            {
                this.gold_ = value;
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

        public int CityDefence
        {
            get
            {
                return this.cityDefence_;
            }
            set
            {
                this.cityDefence_ = value;
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
征集士兵			消耗100金钱，将人口变为士兵，士兵不参与农业生产，但仍会消耗粮食（具体士兵征集数量由实行武将的属性决定） （长期战争会导致人口急剧减少）
修补城池			消耗100金钱，增加城防值（具体增加量由实行武将属性决定）

发展农业：
由武将统率，政治决定效果
统率	政治		效果
1-5		1-10	0.01
1-5		11-16	0.02
1-5		17-20	0.03
6-9		1-9		0.01
6-9		10-14	0.02
6-9		15-18	0.03
6-9		19-20	0.04
10-12	1-8		0.01
10-12	9-12	0.02
10-12	13-16	0.03
10-12	17-18	0.04
10-12	19-20	0.05
13-15	1-7		0.01
13-15	8-10	0.02
13-15	11-15	0.03
13-15	16-17	0.04
13-15	18-19	0.05
13-15	20		0.06
16-18	1-6		0.01
16-18	7-8		0.02
16-18	9-10	0.03
16-18	11-12	0.04
16-18	13-14	0.05
16-18	15-16	0.06
16-18	17		0.07
16-18	18		0.08
16-18	19		0.09
16-18	20		0.1
19-20	1-5		0.01
19-20	6-7		0.02
19-20	8-9		0.03
19-20	10-11	0.04
19-20	12		0.05
19-20	13		0.06
19-20	14		0.07
19-20	15		0.08
19-20	16		0.09
19-20	17		0.1
19-20	18		0.11
19-20	19		0.12
19-20	20		0.13

发展商业：
由武将智力，政治决定效果
智力	政治		效果
1-5		1-10	0.01
1-5		11-16	0.02
1-5		17-20	0.03
6-9		1-9		0.01
6-9		10-14	0.02
6-9		15-18	0.03
6-9		19-20	0.04
10-12	1-8		0.01
10-12	9-12	0.02
10-12	13-16	0.03
10-12	17-18	0.04
10-12	19-20	0.05
13-15	1-7		0.01
13-15	8-10	0.02
13-15	11-15	0.03
13-15	16-17	0.04
13-15	18-19	0.05
13-15	20		0.06
16-18	1-6		0.01
16-18	7-8		0.02
16-18	9-10	0.03
16-18	11-12	0.04
16-18	13-14	0.05
16-18	15-16	0.06
16-18	17		0.07
16-18	18		0.08
16-18	19		0.09
16-18	20		0.1
19-20	1-5		0.01
19-20	6-7		0.02
19-20	8-9		0.03
19-20	10-11	0.04
19-20	12		0.05
19-20	13		0.06
19-20	14		0.07
19-20	15		0.08
19-20	16		0.09
19-20	17		0.1
19-20	18		0.11
19-20	19		0.12
19-20	20		0.13

征集士兵：
由武将统率，政治决定效果
统率	政治		效果
1-5		1-10	100
1-5		11-16	110
1-5		17-20	120
6-9		1-9		100
6-9		10-14	110
6-9		15-18	120
6-9		19-20	130
10-12	1-8		100
10-12	9-12	110
10-12	13-16	120
10-12	17-18	130
10-12	19-20	140
13-15	1-7		100
13-15	8-10	110
13-15	11-15	120
13-15	16-17	130
13-15	18-19	140
13-15	20		150
16-18	1-6		100
16-18	7-8		110
16-18	9-10	120
16-18	11-12	130
16-18	13-14	140
16-18	15-16	150
16-18	17		160
16-18	18		170
16-18	19		180
16-18	20		190
19-20	1-5		100
19-20	6-7		110
19-20	8-9		120
19-20	10-11	130
19-20	12		140
19-20	13		150
19-20	14		160
19-20	15		170
19-20	16		180
19-20	17		190
19-20	18		200
19-20	19		210
19-20	20		220

修补城池：
由武将智力，政治决定效果
智力	政治		效果
1-5		1-10	50
1-5		11-16	100
1-5		17-20	150
6-9		1-9		50
6-9		10-14	100
6-9		15-18	150
6-9		19-20	200
10-12	1-8		50
10-12	9-12	100
10-12	13-16	150
10-12	17-18	200
10-12	19-20	250
13-15	1-7		50
13-15	8-10	100
13-15	11-15	150
13-15	16-17	200
13-15	18-19	250
13-15	20		300
16-18	1-6		50
16-18	7-8		100
16-18	9-10	150
16-18	11-12	200
16-18	13-14	250
16-18	15-16	300
16-18	17		350
16-18	18		400
16-18	19		450
16-18	20		500
19-20	1-5		50
19-20	6-7		100
19-20	8-9		150
19-20	10-11	200
19-20	12		250
19-20	13		300
19-20	14		350
19-20	15		400
19-20	16		450
19-20	17		500
19-20	18		550
19-20	19		600
19-20	20		650
*/