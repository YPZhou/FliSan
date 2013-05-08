using System;
using System.Collections.Generic;
using System.Text;

using FliSan.GameObject.CharacterTraits;
using FliSan.GameAI;

namespace FliSan.GameObject
{
    class CGame
    {
        private CMap map_;
        private List<CFaction> factions_;
        private List<CCity> cities_;
        private List<CCharacter> characters_;
        private CCharacterTraitDictionary traitDictionary_;
        private CGameAIManager gameAIManager_;

        private int gameTurn_;

        public CGame(CGameAIManager _gameAIManager)
        {
            this.map_ = new CMap();
            this.factions_ = new List<CFaction>();
            this.cities_ = new List<CCity>();
            this.characters_ = new List<CCharacter>();
            this.traitDictionary_ = new CCharacterTraitDictionary();
            this.gameAIManager_ = _gameAIManager;
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

        public CFaction GetFactionByIndex(int _index)
        {
            if (_index >= 0 && this.factions_.Count > _index)
            {
                return this.factions_[_index];
            }
            return null;
        }

        public CFaction GetFactionByID(int _id)
        {
            foreach (CFaction faction in this.factions_)
            {
                if (faction.ID == _id)
                {
                    return faction;
                }
            }
            return null;
        }

        public CCity GetCityByIndex(int _index)
        {
            if (_index >= 0 && this.cities_.Count > _index)
            {
                return this.cities_[_index];
            }
            return null;
        }

        public CCity GetCityByID(int _id)
        {
            foreach (CCity city in this.cities_)
            {
                if (city.ID == _id)
                {
                    return city;
                }
            }
            return null;
        }

        public CCharacter GetCharacterByIndex(int _index)
        {
            if (_index >= 0 && this.characters_.Count > _index)
            {
                return this.characters_[_index];
            }
            return null;
        }

        public CCharacter GetCharacterByID(int _id)
        {
            foreach (CCharacter character in this.characters_)
            {
                if (character.ID == _id)
                {
                    return character;
                }
            }
            return null;
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
                faction.Update(this.gameTurn_, this.gameAIManager_);
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

/*
游戏指令
内政：
发展农业    提高粮食收入，需要1名武将，100金钱
发展商业	提高金钱收入，需要1名武将，100金钱
修补城防	提高城市防御值，需要1名武将，100金钱
军事：
征集士兵	将非战斗人口变为士兵，需要1名武将，100金钱
出征		攻击相邻城市，需要1-5名武将，每名武将需要至少50名士兵
运输		在己方相邻城市之间调配物资，士兵，以及武将，运输会在玩家回合结束时到达目的地，执行运输指令没有消耗，但输送的内容在回合结束前将暂时不可用
人事：
评价		听取武将对其他武将的评价，每回合执行次数没有限制
*/
