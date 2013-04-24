using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 笨蛋属性
    class CCharacterTrait31 : CCharacterTraitNormal
    {
        public CCharacterTrait31()
            : base()
        {
            // hates character of same trait
            this.hateList_.Add(31);
        }

        public override String ToString()
        {
            return "笨蛋";
        }
    }
}
