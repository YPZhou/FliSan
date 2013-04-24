using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 礼仪属性
    class CCharacterTrait22 : CCharacterTraitMale
    {
        public CCharacterTrait22()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(22);

            // likes all female traits
            this.likeList_.Add(24);
            this.likeList_.Add(25);
            this.likeList_.Add(26);
            this.likeList_.Add(27);
            this.likeList_.Add(28);
            this.likeList_.Add(29);

            // hates shemale
            this.hateList_.Add(35);
        }

        public override String ToString()
        {
            return "礼仪";
        }
    }
}
