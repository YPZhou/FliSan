using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject
{
    class CArmy
    {
        private List<CTroop> troops_;
        private CFaction faction_;
        private CCity city_;
        private bool isAttacking_;

        public CArmy()
        {
            this.troops_ = new List<CTroop>();
        }
    }
}
