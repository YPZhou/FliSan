using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 病气属性
    class CCharacterTrait30 : CCharacterTraitNormal
    {
        public CCharacterTrait30()
            : base()
        {
            // hates character of same trait
            this.hateList_.Add(30);
        }

        public override String ToString()
        {
            return "病气";
        }
    }
}
