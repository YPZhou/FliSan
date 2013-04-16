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

        private int population_;
        private double foodIncRate_;
        private double goldIncRate_;

        private int cityDefence_;
        private int soldier_;

        public CCity(int _population, double _foodIncRate, double _goldIncRate, int _cityDefence, int _soldier)
        {
            this.population_ = _population;
            this.foodIncRate_ = _foodIncRate;
            this.goldIncRate_ = _goldIncRate;
            this.cityDefence_ = _cityDefence;
            this.soldier_ = _soldier;
        }
    }
}
