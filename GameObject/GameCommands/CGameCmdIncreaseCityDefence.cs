using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdIncreaseCityDefence : IGameCommand
    {
        private CCity city_;
        private CCharacter character_;
        private int goldCost_;

        public CGameCmdIncreaseCityDefence(CCity _city, CCharacter _character, int _goldCost)
        {
            this.city_ = _city;
            this.character_ = _character;
            this.goldCost_ = _goldCost;
        }

        public void Execute()
        {
            if (this.city_.Gold > this.goldCost_ && !this.character_.HasMission)
            {
                this.city_.Gold -= this.goldCost_;
                this.character_.HasMission = true;

                if (this.character_.Stratagem <= 5)
                {
                    if (this.character_.Politics <= 10)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 150;
                    }
                }
                else if (this.character_.Stratagem <= 9)
                {
                    if (this.character_.Politics <= 9)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.CityDefence += 150;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 200;
                    }
                }
                else if (this.character_.Stratagem <= 12)
                {
                    if (this.character_.Politics <= 8)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.CityDefence += 150;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.CityDefence += 200;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 250;
                    }
                }
                else if (this.character_.Stratagem <= 15)
                {
                    if (this.character_.Politics <= 7)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 10)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 15)
                    {
                        this.city_.CityDefence += 150;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.CityDefence += 200;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.CityDefence += 250;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 300;
                    }
                }
                else if (this.character_.Stratagem <= 18)
                {
                    if (this.character_.Politics <= 6)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 8)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 10)
                    {
                        this.city_.CityDefence += 150;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.CityDefence += 200;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.CityDefence += 250;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.CityDefence += 300;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.CityDefence += 350;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.CityDefence += 400;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.CityDefence += 450;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 500;
                    }
                }
                else if (this.character_.Stratagem <= 20)
                {
                    if (this.character_.Politics <= 5)
                    {
                        this.city_.CityDefence += 50;
                    }
                    else if (this.character_.Politics <= 7)
                    {
                        this.city_.CityDefence += 100;
                    }
                    else if (this.character_.Politics <= 9)
                    {
                        this.city_.CityDefence += 150;
                    }
                    else if (this.character_.Politics <= 11)
                    {
                        this.city_.CityDefence += 200;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.CityDefence += 250;
                    }
                    else if (this.character_.Politics <= 13)
                    {
                        this.city_.CityDefence += 300;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.CityDefence += 350;
                    }
                    else if (this.character_.Politics <= 15)
                    {
                        this.city_.CityDefence += 400;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.CityDefence += 450;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.CityDefence += 500;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.CityDefence += 550;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.CityDefence += 600;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.CityDefence += 650;
                    }
                }
            }
        }
    }
}
