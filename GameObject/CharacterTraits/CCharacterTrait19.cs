using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 智谋属性
    class CCharacterTrait19 : CCharacterTraitMale
    {
        public CCharacterTrait19()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(19);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates trait 31
            this.hateList_.Add(31);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "智谋";
        }
    }
}
