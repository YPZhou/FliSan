using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CMap
    {
        private CCity[,] cities_;
        private int width_;
        private int height_;

        public CMap()
        {
            this.cities_ = null;
            this.width_ = 0;
            this.height_ = 0;
        }

        public void CreateMap(int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                this.cities_ = new CCity[_width, _height];
                for (int i = 0; i < _width; i++)
                {
                    for (int j = 0; j < _height; j++)
                    {
                        this.cities_[i, j] = null;
                    }
                }
                this.width_ = _width;
                this.height_ = _height;
            }
        }

        public void PlaceCity(CCity _city)
        {            
            bool canPlaceCity = true;
            for (int i = 0; i < this.width_; i++)
            {
                for (int j = 0; j < this.height_; j++)
                {
                    if (this.cities_[i, j].Equals(_city))
                    {
                        canPlaceCity = false;
                    }
                }
            }

            if (canPlaceCity)
            {
                // ...
            }
        }

        //public void PlaceCities(List<CCity> _cities)
        //{
        //}
    }
}
