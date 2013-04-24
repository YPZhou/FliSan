using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FliSan.GameObject.CharacterTraits;

namespace FliSan.GameObject
{
    class CCharacter
    {
        private int ID_;

        private CFaction faction_;
        private CCity city_;

        private int leaderShip_;
        private int combatSkill_;
        private int stratagem_;
        private int politics_;

        private List<CCharacterTrait> traits_;

        public CCharacter(int _ID, CFaction _faction, CCity _city)
        {
            this.ID_ = _ID;
            this.faction_ = _faction;
            this.city_ = _city;

            this.traits_ = new List<CCharacterTrait>();
        }

        /// <summary>
        /// Adds a trait to this character.
        /// </summary>
        /// <param name="_trait"></param>
        public void AddTrait(CCharacterTrait _trait)
        {
            bool hasOrigin = false;
            bool hasGender = false;
            bool hasFemale = false;
            foreach (CCharacterTrait trait in this.traits_)
            {
                if (trait is CCharacterTraitOrigin)
                {
                    hasOrigin = true;
                }
                if (trait is CCharacterTraitGender)
                {
                    hasGender = true;
                }
                if (trait is CCharacterTraitFemale)
                {
                    hasFemale = true;
                }
            }

            if (hasOrigin && _trait is CCharacterTraitOrigin)
            {                
                return;
            }

            if (hasGender && _trait is CCharacterTraitGender)
            {
                return;
            }

            if (hasFemale && _trait is CCharacterTrait35)
            {
                return;
            }

            this.traits_.Add(_trait);
        }

        /// <summary>
        /// Evaluates "_that".</n>
        /// Gets the "opinion" of character "this" towards character "_that".
        /// </summary>
        /// <param name="_that"></param>
        /// <returns></returns>
        public int Evaluate(CCharacter _that, CCharacterTraitDictionary _dictionary)
        {
            List<CCharacterTrait> likeList = new List<CCharacterTrait>();
            List<CCharacterTrait> hateList = new List<CCharacterTrait>();

            foreach (CCharacterTrait trait in this.traits_)
            {
                likeList.AddRange(trait.Likes(_dictionary));
                hateList.AddRange(trait.Hates(_dictionary));
            }

            int evaluation = 0;
            foreach (CCharacterTrait trait in _that.traits_)
            {
                if (likeList.Contains(trait))
                {
                    evaluation++;
                }
                if (hateList.Contains(trait))
                {
                    evaluation--;
                }
            }
            return evaluation;
        }

        public int LeaderShip
        {
            get
            {
                return this.leaderShip_;
            }
            set
            {
                this.leaderShip_ = value;
            }
        }

        public int CombatSkill
        {
            get
            {
                return this.combatSkill_;
            }
            set
            {
                this.combatSkill_ = value;
            }
        }

        public int Stratagem
        {
            get
            {
                return this.stratagem_;
            }
            set
            {
                this.stratagem_ = value;
            }
        }

        public int Politics
        {
            get
            {
                return this.politics_;
            }
            set
            {
                this.politics_ = value;
            }
        }

        public List<CCharacterTrait> Traits
        {
            get
            {
                return this.traits_;
            }
        }

        public override bool Equals(Object _that)
        {
            if (_that is CCharacter)
            {
                return this.ID_ == ((CCharacter)_that).ID_;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID_;
        }
    }
}
