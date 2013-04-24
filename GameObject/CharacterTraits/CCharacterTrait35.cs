using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 伪娘属性
    class CCharacterTrait35 : CCharacterTraitNormal
    {
        public CCharacterTrait35()
            : base()
        {
            // likes all male traits
            this.likeList_.Add(18);
            this.likeList_.Add(19);
            this.likeList_.Add(20);
            this.likeList_.Add(21);
            this.likeList_.Add(22);
            this.likeList_.Add(23);
        }

        public override String ToString()
        {
            return "伪娘";
        }
    }
}
