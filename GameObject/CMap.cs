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
            List<Tuple<int, int>> emptyGrids = new List<Tuple<int, int>>();
            List<Tuple<int, int>> emptyCandidates = new List<Tuple<int, int>>();
            List<Tuple<int, int>> occupiedCandidates = new List<Tuple<int, int>>();
            for (int i = 0; i < this.width_; i++)
            {
                for (int j = 0; j < this.height_; j++)
                {
                    if (this.cities_[i, j] != null && this.cities_[i, j].Equals(_city))
                    {
                        return;
                    }
                    if (this.cities_[i, j] == null)
                    {
                        int sameFactionCount = 0;
                        if (i > 0)
                        {
                            if (this.cities_[i - 1, j] != null && this.cities_[i - 1, j].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (i < this.width_ - 1)
                        {
                            if (this.cities_[i + 1, j] != null && this.cities_[i + 1, j].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (j > 0)
                        {
                            if (this.cities_[i, j - 1] != null && this.cities_[i, j - 1].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (j < this.height_ - 1)
                        {
                            if (this.cities_[i, j + 1] != null && this.cities_[i, j + 1].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (sameFactionCount > 0)
                        {
                            emptyCandidates.Add(Tuple.Create(i, j));
                        }
                        else
                        {
                            emptyGrids.Add(Tuple.Create(i, j));
                        }
                    }
                    if (this.cities_[i, j] != null && this.cities_[i, j].Faction.ID != _city.Faction.ID)
                    {
                        int sameFactionCount = 0;
                        if (i > 0)
                        {
                            if (this.cities_[i - 1, j] != null && this.cities_[i - 1, j].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (i < this.width_ - 1)
                        {
                            if (this.cities_[i + 1, j] != null && this.cities_[i + 1, j].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (j > 0)
                        {
                            if (this.cities_[i, j - 1] != null && this.cities_[i, j - 1].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (j < this.height_ - 1)
                        {
                            if (this.cities_[i, j + 1] != null && this.cities_[i, j + 1].Faction.ID == _city.Faction.ID)
                            {
                                sameFactionCount++;
                            }
                        }
                        if (sameFactionCount > 0)
                        {
                            occupiedCandidates.Add(Tuple.Create(i, j));
                        }
                    }
                }
            }

            if (emptyGrids.Count == 0 && emptyCandidates.Count == 0 && occupiedCandidates.Count == 0)
            {
                return;
            }
            else if (emptyCandidates.Count > 0)
            {
                int index = rand_.Next(emptyCandidates.Count);
                Tuple<int, int> position = emptyCandidates[index];
                this.cities_[position.Item1, position.Item2] = _city;
                _city.MapCoordX = position.Item1;
                _city.MapCoordY = position.Item2;
            }
            else if (occupiedCandidates.Count > 0)
            {
                int index = rand_.Next(occupiedCandidates.Count);
                Tuple<int, int> position = occupiedCandidates[index];
                CCity city = this.cities_[position.Item1, position.Item2];
                this.cities_[position.Item1, position.Item2] = _city;
                _city.MapCoordX = position.Item1;
                _city.MapCoordY = position.Item2;
                PlaceCity(city);
            }
            else
            {
                int index = rand_.Next(emptyGrids.Count);
                Tuple<int, int> position = emptyGrids[index];
                this.cities_[position.Item1, position.Item2] = _city;
                _city.MapCoordX = position.Item1;
                _city.MapCoordY = position.Item2;
            }
        }

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
