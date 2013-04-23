using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.CharacterTraits
{
    // base interface
    interface ICharacterTrait
    {
        List<ICharacterTrait> Likes();
        List<ICharacterTrait> Hates();
    }

    interface ICharacterTraitOrigin : ICharacterTrait { }               // 出身属性
    interface ICharacterTraitThreeKindom : ICharacterTraitOrigin { }    // 三国出身
    interface ICharacterTraitSengoku : ICharacterTraitOrigin { }        // 战国出身
    interface ICharacterTraitEurope : ICharacterTraitOrigin { }         // 西洋出身
    interface ICharacterTraitGender : ICharacterTrait { }               // 性别属性
    interface ICharacterTraitMale : ICharacterTraitGender { }           // 男性
    interface ICharacterTraitFemale : ICharacterTraitGender { }         // 女性
    interface ICharacterTraitNormal : ICharacterTrait { }               // 其他属性

    /*
        出身 显式属性 三国类（汉官，诸侯，英杰，盗贼，富绅，文豪） 战国类（公卿，武士，僧侣，忍者，商人，茶人） 西洋类（领主，骑士，学者，教廷，海盗，工匠）
        特性 隐式属性 男性（武勇，智谋，忠义，仁德，礼仪，守信） 女性（萝莉，御姐，人妻，女仆，魔法少女，姬） 中性（病气，笨蛋，战斗力5，傲娇，M，伪娘）

        每个武将拥有一种出身，一种性别特性及一种中性特性
        相同出身小类									+1			喜欢相同出身小类
        同性同特性									    +1			喜欢相同性别特性
        异性											+1			喜欢全部异性特性

        不同出身小类									-1			讨厌全部不同出身小类
        不同出身大类									-1			讨厌全部不同出身大类
        相同中性特性									-1			讨厌相同中性特性

        萝莉对富绅									    +1			喜欢富绅
        御姐对英杰									    +1			喜欢英杰
        人妻对异性									    +1			喜欢全部男性特性
        女仆对汉官、诸侯、公卿、武士、领主、骑士		+1			喜欢汉官、诸侯、公卿、武士、领主、骑士
        魔法少女对教廷								    +1			喜欢教廷
        姬对武士										+1			喜欢武士

        武勇对病气									    -1			讨厌病气
        智谋对笨蛋									    -1			讨厌笨蛋
        忠义对傲娇									    -1			讨厌傲娇
        仁德对M										    -1			讨厌M
        礼仪对伪娘									    -1			讨厌伪娘
        守信对战斗力5									-1			讨厌战斗力5

        男性对伪娘									    -1			讨厌伪娘
        伪娘对男性									    +1			喜欢全部男性特性

        男性盗贼及海盗对真女性							+1			喜欢全部女性特性
        女性对盗贼及海盗								-1			讨厌盗贼及海盗

        骑士对真女性									+1			喜欢全部女性特性
        女性对骑士									    +1			喜欢骑士
        礼仪对真女性									+1			喜欢全部女性特性
        女性对礼仪									    +1			喜欢礼仪
     */
}
