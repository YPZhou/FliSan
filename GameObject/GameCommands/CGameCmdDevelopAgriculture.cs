using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdDevelopAgriculture : IGameCommand
    {
        private CCity city_;
        private CCharacter character_;
        private int goldCost_;

        public CGameCmdDevelopAgriculture(CCity _city, CCharacter _character, int _goldCost)
        {
            this.city_ = _city;
            this.character_ = _character;
            this.goldCost_ = _goldCost;
        }

        public void Execute()
        {
            if (this.city_.Gold > this.goldCost_)
            {
                this.city_.Gold -= this.goldCost_;
                //this.city_.FoodIncreaseRate += ;
            }
        }
    }
}
