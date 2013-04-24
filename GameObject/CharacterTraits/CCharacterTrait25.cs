using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 御姐属性
    class CCharacterTrait25 : CCharacterTraitFemale
    {
        public CCharacterTrait25()
            : base()
        {
            // likes character of same trait
            this.likeList_.Add(25);

            // likes all male traits
            this.likeList_.Add(18);
            this.likeList_.Add(19);
            this.likeList_.Add(20);
            this.likeList_.Add(21);
            this.likeList_.Add(22);
            this.likeList_.Add(23);

            // likes trait 2
            this.likeList_.Add(2);

            // likes knight
            this.likeList_.Add(13);

            // hates thief and pirate
            this.hateList_.Add(3);
            this.hateList_.Add(16);
        }

        public override String ToString()
        {
            return "御姐";
        }
    }
}
