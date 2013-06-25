using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FliSan.GameObject.GameCommands;

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
        private int injuredSoldier_;

        private List<IGameCommand> gameCommands_;

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

            this.cityDefence_ = 100;
            this.soldier_ = 500;
            this.injuredSoldier_ = 0;

            this.gameCommands_ = new List<IGameCommand>();
        }

        public void Update(int _gameTurn)
        {
            foreach (CCharacter character in this.characters_)
            {
                character.HasMission = false;
            }
            foreach (IGameCommand gameCommand in this.gameCommands_)
            {
                gameCommand.Execute();
            }
            this.gameCommands_.Clear();

            // food updates
            int foodConsumption = (int)Math.Ceiling(this.population_ * this.foodConsumpRate_);
            int foodIncrease = 0;

            // check food increase every month (6 turns)
            if (_gameTurn % 6 == 0)
            {
                // food increase rate is doubled in autumn
                if (_gameTurn % 72 > 36 && _gameTurn % 72 < 55)
                {
                    foodIncrease = (int)Math.Ceiling(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ * 2);
                }
                else
                {
                    foodIncrease = (int)Math.Ceiling(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_);
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
                    this.population_ += (int)Math.Ceiling(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ / 15.0);
                }
            }
            else
            {
                // check population decrease every 5 days (1 turn)
                this.population_ = Math.Max(this.population_ - (int)Math.Ceiling(foodShortage / 1.5), 0);
                this.soldier_ = Math.Max(this.soldier_ - (int)Math.Ceiling(foodShortage / 1.5), 0);
            }

            // gold updates            
            // check gold increase every 5 days (1 turn)

            // gold increase rate is doubled in winter
            if (_gameTurn % 72 > 54 && _gameTurn % 72 <= 71)
            {
                this.gold_ += (int)Math.Ceiling(Math.Max(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ / 6.0 - foodConsumption, 0) * this.goldIncRate_ * 2);
            }
            else
            {
                this.gold_ += (int)Math.Ceiling(Math.Max(Math.Min(this.population_ - this.soldier_, this.maxAgriculturePopulation_) * this.foodIncRate_ / 6.0 - foodConsumption, 0) * this.goldIncRate_);
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

        public void PushGameCommands(List<IGameCommand> _gameCommands)
        {
            this.gameCommands_.AddRange(_gameCommands);
        }

        public void ApplyCityDamage(int _damage)
        {
            int maxLeaderShip = 0;
            int maxPolitics = 0;
            foreach (CCharacter character in this.characters_)
            {
                if (character.LeaderShip > maxLeaderShip)
                {
                    maxLeaderShip = character.LeaderShip;
                }
                if (character.Politics > maxPolitics)
                {
                    maxPolitics = character.Politics;
                }
            }
            double leaderShipFactor = 1 - (maxLeaderShip - 8) / 24.0;
            double politicsFactor = 1 - (maxPolitics - 8) / 24.0;

            if (this.cityDefence_ > 0)
            {
                this.cityDefence_ = Math.Max(this.cityDefence_ - (int)Math.Ceiling(_damage * politicsFactor), 0);
            }
            else
            {
                this.foodIncRate_ = Math.Max(this.foodIncRate_ - _damage / 800.0 * leaderShipFactor, 0);
                this.goldIncRate_ = Math.Max(this.goldIncRate_ - _damage / 800.0 * leaderShipFactor, 0);
                this.population_ = Math.Max(this.population_ - (int)Math.Ceiling(_damage / 0.8 * leaderShipFactor), 0);
            }
        }

        public int ID
        {
            get
            {
                return this.ID_;
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

        public double FoodIncreaseRate
        {
            get
            {
                return this.foodIncRate_;
            }
            set
            {
                this.foodIncRate_ = value;
            }
        }

        public double GoldIncreaseRate
        {
            get
            {
                return this.goldIncRate_;
            }
            set
            {
                this.goldIncRate_ = value;
            }
        }

        public int Population
        {
            get
            {
                return this.population_;
            }
            set
            {
                this.population_ = value;
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

        public bool IsCityDefenceBroken
        {
            get
            {
                return this.cityDefence_ <= 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("城防\t" + this.cityDefence_.ToString() + "\t士兵\t" + this.soldier_.ToString() + "\t人口\t" + this.population_.ToString() + "\t粮食收入\t" + this.foodIncRate_.ToString() + "\t金钱收入\t" + this.goldIncRate_.ToString() + "\t粮食\t" + this.food_.ToString() + "\t金钱\t" + this.gold_.ToString());
            return sb.ToString();
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