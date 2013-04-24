using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 傲娇属性
    class CCharacterTrait33 : CCharacterTraitNormal
    {
        public CCharacterTrait33()
            : base()
        {
            // hates character of same trait
            this.hateList_.Add(33);
        }

        public override String ToString()
        {
            return "傲娇";
        }
    }
}
