﻿using System;

namespace FliSan.GameObject.CharacterTraits
{
    // 领主出身
    class CCharacterTrait12 : CCharacterTraitEurope
    {
        public CCharacterTrait12()
            : base()
        {
            // likes character of same origin
            this.likeList_.Add(12);

            // hates character of different origins
            this.hateList_.Add(0);
            this.hateList_.Add(1);
            this.hateList_.Add(2);
            this.hateList_.Add(3);
            this.hateList_.Add(4);
            this.hateList_.Add(5);
            this.hateList_.Add(6);
            this.hateList_.Add(7);
            this.hateList_.Add(8);
            this.hateList_.Add(9);
            this.hateList_.Add(10);
            this.hateList_.Add(11);
            this.hateList_.Add(13);
            this.hateList_.Add(14);
            this.hateList_.Add(15);
            this.hateList_.Add(16);
            this.hateList_.Add(17);
        }

        public override String ToString()
        {
            return "领主";
        }
    }
}
