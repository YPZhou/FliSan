using System;
using System.Collections.Generic;
using System.Text;

using FliSan.GameObject.CharacterTraits;

namespace FliSan.GameObject
{
    class CGame
    {
        private CMap map_;
        private List<CFaction> factions_;
        private List<CCity> cities_;
        private List<CCharacter> characters_;
        private CCharacterTraitDictionary traitDictionary_;

        private int gameTurn_;

        public CGame()
        {
            this.map_ = new CMap();
            this.factions_ = new List<CFaction>();
            this.cities_ = new List<CCity>();
            this.characters_ = new List<CCharacter>();
            this.traitDictionary_ = new CCharacterTraitDictionary();
        }

        public void CreateGame(int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                this.map_.CreateMap(_width, _height);

                int cityCount = _width * _height;
                int factionCount = (int)(cityCount * 0.75);
                int characterCount = cityCount * 5;

                this.cities_.Clear();
                this.factions_.Clear();
                this.characters_.Clear();

                for (int i = 0; i < factionCount; i++)
                {
                    CFaction faction = new CFaction(this.factions_.Count + 1, false);
                    this.factions_.Add(faction);

                    CCity city = new CCity(this.cities_.Count + 1, faction);
                    this.cities_.Add(city);
                    faction.AddCity(city);
                    this.map_.PlaceCity(city);                    

                    for (int j = 0; j < 5; j++)
                    {
                        CCharacter character = new CCharacter(this.characters_.Count + 1, faction, city);
                        character.RandomGeneration(this.traitDictionary_);
                        this.characters_.Add(character);
                        faction.AddCharacter(character);
                        city.AddCharacter(character);                        
                    }

                    // create big faction
                    // big faction has one more city
                    if (cityCount - this.cities_.Count > factionCount - this.factions_.Count)
                    {
                        city = new CCity(this.cities_.Count + 1, faction);
                        this.cities_.Add(city);
                        faction.AddCity(city);
                        this.map_.PlaceCity(city);                        

                        for (int j = 0; j < 5; j++)
                        {
                            CCharacter character = new CCharacter(this.characters_.Count + 1, faction, city);
                            character.RandomGeneration(this.traitDictionary_);
                            this.characters_.Add(character);
                            faction.AddCharacter(character);
                            city.AddCharacter(character);
                        }
                    }
                }
            }
        }

        public void LoadGame(String _path)
        {
        }

        public void SaveGame(String _path)
        {
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.map_.Width; i++)
            {
                for (int j = 0; j < this.map_.Height; j++)
                {
                    CCity city = this.map_[i, j];
                    if (city != null)
                    {
                        sb.Append("|\t" + city.Faction.ID + "\t|");
                    }
                    else
                    {
                        sb.Append("|\tX\t|");
                    }
                }
                sb.Append("\n");
            }

            sb.Append("\n");

            for (int i = 0; i < this.characters_.Count; i++)
            {
                CCharacter character = this.characters_[i];
                CFaction faction = character.Faction;
                CCharacter evaluator = faction.Characters[0];
                List<int> attributes = evaluator.Evaluate(character, this.traitDictionary_);
                sb.Append("势力：" + character.Faction.ID + "\t" + "统率：" + attributes[0] + "(" + character.LeaderShip + ")" + "\t" + "武力：" + attributes[1] + "(" + character.CombatSkill + ")" + "\t" + "智力：" + attributes[2] + "(" + character.Stratagem + ")" + "\t" + "政治：" + attributes[3] + "(" + character.Politics + ")" + "\t" + "相性：" + evaluator.Judgement(character, this.traitDictionary_));
                foreach (CCharacterTrait trait in character.Traits)
                {
                    sb.Append("\t" + trait.ToString());
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public void Update()
        {
            foreach (CFaction faction in this.factions_)
            {
                faction.Update(this.gameTurn_);
            }

            this.gameTurn_++;
        }

        public CMap Map
        {
            get
            {
                return this.map_;
            }
        }
    }
}
