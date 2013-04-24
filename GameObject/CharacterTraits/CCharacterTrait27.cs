using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 女仆属性
    class CCharacterTrait27 : CCharacterTraitFemale
    {
        public CCharacterTrait27()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(27);

            // likes all male traits
            this.likeList_.Add(18);
            this.likeList_.Add(19);
            this.likeList_.Add(20);
            this.likeList_.Add(21);
            this.likeList_.Add(22);
            this.likeList_.Add(23);

            // likes trait 0
            this.likeList_.Add(0);

            // likes trait 1
            this.likeList_.Add(1);

            // likes trait 6
            this.likeList_.Add(6);

            // likes trait 7
            this.likeList_.Add(7);

            // likes trait 12
            this.likeList_.Add(12);

            // likes trait 13
            this.likeList_.Add(13);

            // likes knight
            this.likeList_.Add(13);

            // hates thief and pirate
            this.hateList_.Add(3);
            this.hateList_.Add(16);
        }

        public override String ToString()
        {
            return "女仆";
        }
    }
}
