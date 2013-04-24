using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 抖M属性
    class CCharacterTrait34 : CCharacterTraitNormal
    {
        public CCharacterTrait34()
            : base()
        {
            // hates character of same trait
            this.hateList_.Add(34);
        }

        public override String ToString()
        {
            return "抖M";
        }
    }
}
