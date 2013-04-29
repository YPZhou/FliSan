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

        public int GetCityDamage(int _soldierInTotal)
        {
            return 0;
        }

        public int GetCityMoraleDamage()
        {
            return 0;
        }

        public void ApplyCityDamage(int _damage)
        {
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
