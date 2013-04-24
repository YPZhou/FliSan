using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 忠义属性
    class CCharacterTrait20 : CCharacterTraitMale
    {
        public CCharacterTrait20()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(20);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates trait 33
            this.hateList_.Add(33);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "忠义";
        }
    }
}
