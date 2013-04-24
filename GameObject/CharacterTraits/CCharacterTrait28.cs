using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 魔法少女属性
    class CCharacterTrait28 : CCharacterTraitFemale
    {
        public CCharacterTrait28()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(28);

            // likes all male traits
            this.likeList_.Add(18);
            this.likeList_.Add(19);
            this.likeList_.Add(20);
            this.likeList_.Add(21);
            this.likeList_.Add(22);
            this.likeList_.Add(23);

            // likes trait 15
            this.likeList_.Add(15);

            // likes knight
            this.likeList_.Add(13);

            // hates thief and pirate
            this.hateList_.Add(3);
            this.hateList_.Add(16);
        }

        public override String ToString()
        {
            return "魔法少女";
        }
    }
}
