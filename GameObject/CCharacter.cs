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

        private bool hasMission_;

        private static Random rand = new Random();

        public CCharacter(int _ID, CFaction _faction, CCity _city)
        {
            this.ID_ = _ID;
            this.faction_ = _faction;
            this.city_ = _city;

            this.traits_ = new List<CCharacterTrait>();

            this.hasMission_ = false;
        }

        /// <summary>
        /// Generates a character randomly.
        /// </summary>
        /// <param name="_dictionary"></param>
        public void RandomGeneration(CCharacterTraitDictionary _dictionary)
        {
            this.leaderShip_ = rand.Next(1, 21);
            this.combatSkill_ = rand.Next(1, 21);
            this.stratagem_ = rand.Next(1, 21);
            this.politics_ = rand.Next(1, 21);

            int origin = rand.Next(18);
            int gender = rand.Next(18, 30);
            int normal = _dictionary[gender] is CCharacterTraitMale ? rand.Next(30, 36) : rand.Next(30, 35);

            this.traits_.Add(_dictionary[origin]);
            this.traits_.Add(_dictionary[gender]);
            this.traits_.Add(_dictionary[normal]);
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
        /// Judges "_that".<br/>
        /// Gets the "opinion" of character "this" towards character "_that".
        /// </summary>
        /// <param name="_that"></param>
        /// <returns></returns>
        public int Judgement(CCharacter _that, CCharacterTraitDictionary _dictionary)
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

        /// <summary>
        /// Evaluates "_that"<br/>
        /// Gets the evaluation of attributes of character "_that", based on the judgement value.
        /// </summary>
        /// <param name="_that"></param>
        /// <returns></returns>
        public List<int> Evaluate(CCharacter _that, CCharacterTraitDictionary _dictionary)
        {
            List<int> evals = new List<int>();
            evals.Add(_that.leaderShip_);
            evals.Add(_that.combatSkill_);
            evals.Add(_that.stratagem_);
            evals.Add(_that.politics_);

            int judgement = this.Judgement(_that, _dictionary);
            int sign = Math.Sign(judgement);
            float error = (20 - this.stratagem_) / 50.0f;

            for (int i = 0; i < evals.Count; i++)
            {
                evals[i] += (int)(evals[i] * error + sign * judgement) * sign;
                if (evals[i] < 1) evals[i] = 1;
            }

            return evals;
        }

        public int ID
        {
            get
            {
                return this.ID_;
            }
        }

        public CFaction Faction
        {
            get
            {
                return this.faction_;
            }
            set
            {
                this.faction_ = value;
            }
        }

        public CCity City
        {
            get
            {
                return this.city_;
            }
            set
            {
                this.city_ = value;
            }
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

        public bool HasMission
        {
            get
            {
                return this.hasMission_;
            }
            set
            {
                this.hasMission_ = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
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
