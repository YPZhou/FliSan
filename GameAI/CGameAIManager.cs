﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;

namespace FliSan.GameAI
{
    class CGameAIManager
    {
        public CGameAIManager()
        {
        }

        public void Update(CGame _game)
        {
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
 */
