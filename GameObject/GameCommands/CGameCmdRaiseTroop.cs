using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.GameCommands
{
    class CGameCmdRaiseTroop : IGameCommand
    {
        private CCity city_;
        private CCharacter character_;
        private int goldCost_;

        public CGameCmdRaiseTroop(CCity _city, CCharacter _character, int _goldCost)
        {
            this.city_ = _city;
            this.character_ = _character;
            this.goldCost_ = _goldCost;
        }

        public void Execute()
        {
            if (this.city_.Gold >= this.goldCost_ && !this.character_.HasMission)
            {
                this.city_.Gold -= this.goldCost_;
                this.character_.HasMission = true;

                if (this.character_.LeaderShip <= 5)
                {
                    if (this.character_.Politics <= 10)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 120;
                    }
                }
                else if (this.character_.LeaderShip <= 9)
                {
                    if (this.character_.Politics <= 9)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.Soldier += 120;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 130;
                    }
                }
                else if (this.character_.LeaderShip <= 12)
                {
                    if (this.character_.Politics <= 8)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.Soldier += 120;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.Soldier += 130;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 140;
                    }
                }
                else if (this.character_.LeaderShip <= 15)
                {
                    if (this.character_.Politics <= 7)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 10)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 15)
                    {
                        this.city_.Soldier += 120;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.Soldier += 130;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.Soldier += 140;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 150;
                    }
                }
                else if (this.character_.LeaderShip <= 18)
                {
                    if (this.character_.Politics <= 6)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 8)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 10)
                    {
                        this.city_.Soldier += 120;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.Soldier += 130;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.Soldier += 140;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.Soldier += 150;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.Soldier += 160;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.Soldier += 170;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.Soldier += 180;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 190;
                    }
                }
                else if (this.character_.LeaderShip <= 20)
                {
                    if (this.character_.Politics <= 5)
                    {
                        this.city_.Soldier += 100;
                    }
                    else if (this.character_.Politics <= 7)
                    {
                        this.city_.Soldier += 110;
                    }
                    else if (this.character_.Politics <= 9)
                    {
                        this.city_.Soldier += 120;
                    }
                    else if (this.character_.Politics <= 11)
                    {
                        this.city_.Soldier += 130;
                    }
                    else if (this.character_.Politics <= 12)
                    {
                        this.city_.Soldier += 140;
                    }
                    else if (this.character_.Politics <= 13)
                    {
                        this.city_.Soldier += 150;
                    }
                    else if (this.character_.Politics <= 14)
                    {
                        this.city_.Soldier += 160;
                    }
                    else if (this.character_.Politics <= 15)
                    {
                        this.city_.Soldier += 170;
                    }
                    else if (this.character_.Politics <= 16)
                    {
                        this.city_.Soldier += 180;
                    }
                    else if (this.character_.Politics <= 17)
                    {
                        this.city_.Soldier += 190;
                    }
                    else if (this.character_.Politics <= 18)
                    {
                        this.city_.Soldier += 200;
                    }
                    else if (this.character_.Politics <= 19)
                    {
                        this.city_.Soldier += 210;
                    }
                    else if (this.character_.Politics <= 20)
                    {
                        this.city_.Soldier += 220;
                    }
                }
            }
        }
    }
}
