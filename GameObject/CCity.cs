using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CCity
    {
        private CFaction faction_;
        private List<CCharacter> characters_;

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

        public CCity(int _maxAgriculturePopulation, int _population, int _gold, int _food, double _foodIncRate, double _goldIncRate, int _cityDefence, int _soldier)
        {
            this.maxAgriculturePopulation_ = _maxAgriculturePopulation;
            this.population_ = _population;
            this.gold_ = _gold;
            this.food_ = _food;
            this.populationLoseCounter_ = 1;
            this.populationGainCounter_ = 1;
            this.foodIncRate_ = _foodIncRate;
            this.goldIncRate_ = _goldIncRate;
            this.cityDefence_ = _cityDefence;
            this.soldier_ = _soldier;
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
    }
}
