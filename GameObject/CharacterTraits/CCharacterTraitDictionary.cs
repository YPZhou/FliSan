using System;
using System.Collections.Generic;

namespace FliSan.GameObject.CharacterTraits
{
    class CCharacterTraitDictionary
    {
        private List<CCharacterTrait> traitList_;
        private Dictionary<String, CCharacterTrait> traitIndexStr_;
        private Dictionary<int, CCharacterTrait> traitIndexInt_;

        public CCharacterTraitDictionary()
        {
            this.traitList_ = new List<CCharacterTrait>();
            this.traitList_.Add(new CCharacterTrait0());
            this.traitList_.Add(new CCharacterTrait1());
            this.traitList_.Add(new CCharacterTrait2());
            this.traitList_.Add(new CCharacterTrait3());
            this.traitList_.Add(new CCharacterTrait4());
            this.traitList_.Add(new CCharacterTrait5());
            this.traitList_.Add(new CCharacterTrait6());
            this.traitList_.Add(new CCharacterTrait7());
            this.traitList_.Add(new CCharacterTrait8());
            this.traitList_.Add(new CCharacterTrait9());
            this.traitList_.Add(new CCharacterTrait10());
            this.traitList_.Add(new CCharacterTrait11());
            this.traitList_.Add(new CCharacterTrait12());
            this.traitList_.Add(new CCharacterTrait13());
            this.traitList_.Add(new CCharacterTrait14());
            this.traitList_.Add(new CCharacterTrait15());
            this.traitList_.Add(new CCharacterTrait16());
            this.traitList_.Add(new CCharacterTrait17());
            this.traitList_.Add(new CCharacterTrait18());
            this.traitList_.Add(new CCharacterTrait19());
            this.traitList_.Add(new CCharacterTrait20());
            this.traitList_.Add(new CCharacterTrait21());
            this.traitList_.Add(new CCharacterTrait22());
            this.traitList_.Add(new CCharacterTrait23());
            this.traitList_.Add(new CCharacterTrait24());
            this.traitList_.Add(new CCharacterTrait25());
            this.traitList_.Add(new CCharacterTrait26());
            this.traitList_.Add(new CCharacterTrait27());
            this.traitList_.Add(new CCharacterTrait28());
            this.traitList_.Add(new CCharacterTrait29());
            this.traitList_.Add(new CCharacterTrait30());
            this.traitList_.Add(new CCharacterTrait31());
            this.traitList_.Add(new CCharacterTrait32());
            this.traitList_.Add(new CCharacterTrait33());
            this.traitList_.Add(new CCharacterTrait34());
            this.traitList_.Add(new CCharacterTrait35());

            this.traitIndexInt_ = new Dictionary<int, CCharacterTrait>();
            this.traitIndexInt_.Add(0, this.traitList_[0]);
            this.traitIndexInt_.Add(1, this.traitList_[1]);
            this.traitIndexInt_.Add(2, this.traitList_[2]);
            this.traitIndexInt_.Add(3, this.traitList_[3]);
            this.traitIndexInt_.Add(4, this.traitList_[4]);
            this.traitIndexInt_.Add(5, this.traitList_[5]);
            this.traitIndexInt_.Add(6, this.traitList_[6]);
            this.traitIndexInt_.Add(7, this.traitList_[7]);
            this.traitIndexInt_.Add(8, this.traitList_[8]);
            this.traitIndexInt_.Add(9, this.traitList_[9]);
            this.traitIndexInt_.Add(10, this.traitList_[10]);
            this.traitIndexInt_.Add(11, this.traitList_[11]);
            this.traitIndexInt_.Add(12, this.traitList_[12]);
            this.traitIndexInt_.Add(13, this.traitList_[13]);
            this.traitIndexInt_.Add(14, this.traitList_[14]);
            this.traitIndexInt_.Add(15, this.traitList_[15]);
            this.traitIndexInt_.Add(16, this.traitList_[16]);
            this.traitIndexInt_.Add(17, this.traitList_[17]);
            this.traitIndexInt_.Add(18, this.traitList_[18]);
            this.traitIndexInt_.Add(19, this.traitList_[19]);
            this.traitIndexInt_.Add(20, this.traitList_[20]);
            this.traitIndexInt_.Add(21, this.traitList_[21]);
            this.traitIndexInt_.Add(22, this.traitList_[22]);
            this.traitIndexInt_.Add(23, this.traitList_[23]);
            this.traitIndexInt_.Add(24, this.traitList_[24]);
            this.traitIndexInt_.Add(25, this.traitList_[25]);
            this.traitIndexInt_.Add(26, this.traitList_[26]);
            this.traitIndexInt_.Add(27, this.traitList_[27]);
            this.traitIndexInt_.Add(28, this.traitList_[28]);
            this.traitIndexInt_.Add(29, this.traitList_[29]);
            this.traitIndexInt_.Add(30, this.traitList_[30]);
            this.traitIndexInt_.Add(31, this.traitList_[31]);
            this.traitIndexInt_.Add(32, this.traitList_[32]);
            this.traitIndexInt_.Add(33, this.traitList_[33]);
            this.traitIndexInt_.Add(34, this.traitList_[34]);
            this.traitIndexInt_.Add(35, this.traitList_[35]);

            this.traitIndexStr_ = new Dictionary<string, CCharacterTrait>();
            this.traitIndexStr_.Add("汉官", this.traitList_[0]);
            this.traitIndexStr_.Add("诸侯", this.traitList_[1]);
            this.traitIndexStr_.Add("英杰", this.traitList_[2]);
            this.traitIndexStr_.Add("盗贼", this.traitList_[3]);
            this.traitIndexStr_.Add("富绅", this.traitList_[4]);
            this.traitIndexStr_.Add("文豪", this.traitList_[5]);
            this.traitIndexStr_.Add("公卿", this.traitList_[6]);
            this.traitIndexStr_.Add("武士", this.traitList_[7]);
            this.traitIndexStr_.Add("僧侣", this.traitList_[8]);
            this.traitIndexStr_.Add("忍者", this.traitList_[9]);
            this.traitIndexStr_.Add("商人", this.traitList_[10]);
            this.traitIndexStr_.Add("茶人", this.traitList_[11]);
            this.traitIndexStr_.Add("领主", this.traitList_[12]);
            this.traitIndexStr_.Add("骑士", this.traitList_[13]);
            this.traitIndexStr_.Add("学者", this.traitList_[14]);
            this.traitIndexStr_.Add("教廷", this.traitList_[15]);
            this.traitIndexStr_.Add("海盗", this.traitList_[16]);
            this.traitIndexStr_.Add("工匠", this.traitList_[17]);
            this.traitIndexStr_.Add("武勇", this.traitList_[18]);
            this.traitIndexStr_.Add("智谋", this.traitList_[19]);
            this.traitIndexStr_.Add("忠义", this.traitList_[20]);
            this.traitIndexStr_.Add("仁德", this.traitList_[21]);
            this.traitIndexStr_.Add("礼仪", this.traitList_[22]);
            this.traitIndexStr_.Add("守信", this.traitList_[23]);
            this.traitIndexStr_.Add("萝莉", this.traitList_[24]);
            this.traitIndexStr_.Add("御姐", this.traitList_[25]);
            this.traitIndexStr_.Add("人妻", this.traitList_[26]);
            this.traitIndexStr_.Add("女仆", this.traitList_[27]);
            this.traitIndexStr_.Add("魔法少女", this.traitList_[28]);
            this.traitIndexStr_.Add("姬", this.traitList_[29]);
            this.traitIndexStr_.Add("病气", this.traitList_[30]);
            this.traitIndexStr_.Add("笨蛋", this.traitList_[31]);
            this.traitIndexStr_.Add("战斗力5", this.traitList_[32]);
            this.traitIndexStr_.Add("傲娇", this.traitList_[33]);
            this.traitIndexStr_.Add("抖M", this.traitList_[34]);
            this.traitIndexStr_.Add("伪娘", this.traitList_[35]);
        }

        public CCharacterTrait this[int _index]
        {
            get
            {
                return this.traitIndexInt_[_index];
            }
        }

        public CCharacterTrait this[String _index]
        {
            get
            {
                return this.traitIndexStr_[_index];
            }
        }
    }
}
