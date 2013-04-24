using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 武勇属性
    class CCharacterTrait18 : CCharacterTraitMale
    {
        public CCharacterTrait18()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(18);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates trait 30
            this.hateList_.Add(30);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "武勇";
        }
    }
}
