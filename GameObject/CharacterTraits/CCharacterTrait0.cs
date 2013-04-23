using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FliSan.GameObject.CharacterTraits
{
    // 汉官出身
    class CCharacterTrait0 : CCharacterTraitThreeKindom
    {
        public CCharacterTrait0()
            : base()
        {
            this.likeList_.Add(0);
        }

        public override String ToString()
        {
            return "汉官";
        }
    }
}
