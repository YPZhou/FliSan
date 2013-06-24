using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;
using FliSan.GameObject.GameCommands;

namespace FliSan.GameAI
{
    class CGameAIManager
    {
        private IGameAI gameAI_;
        private Dictionary<int, IGameCommand> cityGameCommands_;

        public CGameAIManager()
        {
            this.gameAI_ = new CGameAIRandom();
            this.cityGameCommands_ = new Dictionary<int, IGameCommand>();
        }

        public void Update(CGame _game)
        {
            this.gameAI_.Run(_game, this.cityGameCommands_);
        }

        public IGameCommand GetGameCommand(int _cityID)
        {
            if (this.cityGameCommands_.ContainsKey(_cityID))
            {
                return this.cityGameCommands_[_cityID];
            }
            else
            {
                return new CGameCmdNone();
            }
        }
    }
}

/*
AI系统
宏观AI： 决定目标势力
1 以所有相邻势力为选择范围
2 城市数量越少的势力得分越高
3 军事实力越弱的势力得分越高
4 经济实力越强的势力得分越高
5 周围势力越强的势力得分越高

微观AI： 根据目标势力决定每回合的指令
1 军事实力，兵力调整，粮食调整
 a 以相邻势力的最高兵力为基准，计算每个城市的危险程度
 b 根据每个城市的经济实力决定城市的重要程度
 c 向重要且危险的城市集中兵力和粮食
 d 不与敌对势力相邻的城市危险度为0，不放置任何士兵
 e 危险度高的城市优先执行征兵指令（武将征兵的效率阀值降低）

2 内政开发，金钱调整
 a 以发展农业优先（相同效率阀值时，武将优先发展农业）
 b 金钱向需要开发的城市集中

3 军事评估，攻击目标


AI计算流程
1 势力情况
势力根据每座城市的周边情况，计算该城市每个指令的权重

2 武将能力
该势力的每名武将根据自身能力值，计算自己执行每个指令的效率值（也可以在创建武将时就先行计算好）

3 选择指令
武将的指令效率值与城市的指令权重相加，得到指令的最终判定值，武将选择执行判定值最优的指令

AI搜索空间
所有武将可能执行的指令，暴力搜索该空间，找出最优解

搜索空间缩减
对搜索空间进行暴力搜索之前，先使用贪心算法进行城市间的输送，减少可以执行指令的武将数量
另外同样使用贪心算法，排除一些绝对不会执行的指令，比如提高非前线城市的城防

 */
