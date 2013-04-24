using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 战斗力5属性
    class CCharacterTrait32 : CCharacterTraitNormal
    {
        public CCharacterTrait32()
            : base()
        {
            // hates character of same trait
            this.hateList_.Add(32);
        }

        public override String ToString()
        {
            return "战斗力5";
        }
    }
}
