using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CMap
    {
        private CCity[,] cities_;

        public CMap()
        {
            int x = 1;
            int y = 2;
            cities_ = new CCity[x, y];
        }
    }
}
