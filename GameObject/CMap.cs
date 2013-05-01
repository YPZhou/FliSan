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

        private Random rand_;

        public CMap()
        {
            this.cities_ = null;
            this.width_ = 0;
            this.height_ = 0;
            this.rand_ = new Random();
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
                    if (this.cities_[i, j] != null && this.cities_[i, j].Equals(_city))
                    {
                        canPlaceCity = false;
                    }
                }
            }

            if (canPlaceCity)
            {
                int x = rand_.Next(this.width_);
                int y = rand_.Next(this.height_);
                while (this.cities_[x, y] != null)
                {
                    x = rand_.Next(this.width_);
                    y = rand_.Next(this.height_);
                }
                this.cities_[x, y] = _city;
                _city.MapCoordX = x;
                _city.MapCoordY = y;
            }
        }

        //public void PlaceCities(List<CCity> _cities)
        //{
        //}

        public int Width
        {
            get
            {
                return this.width_;
            }
        }

        public int Height
        {
            get
            {
                return this.height_;
            }
        }

        public CCity this[int i, int j]
        {
            get
            {
                return this.cities_[i, j];
            }
        }
    }
}
