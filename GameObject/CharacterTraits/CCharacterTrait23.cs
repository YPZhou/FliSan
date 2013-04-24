using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 守信属性
    class CCharacterTrait23 : CCharacterTraitMale
    {
        public CCharacterTrait23()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(23);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates trait 32
            this.hateList_.Add(32);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "守信";
        }
    }
}
