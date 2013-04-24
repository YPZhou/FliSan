using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 仁德属性
    class CCharacterTrait21 : CCharacterTraitMale
    {
        public CCharacterTrait21()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(21);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates trait 34
            this.hateList_.Add(34);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "仁德";
        }
    }
}
