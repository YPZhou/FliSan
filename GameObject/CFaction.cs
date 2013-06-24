using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FliSan.GameAI;

namespace FliSan.GameObject
{
    class CFaction
    {
        private int ID_;

        private List<CCity> cities_;
        private List<CCharacter> characters_;        

        private bool controlledByPlayer_;

        public CFaction(int _ID, bool _controlledByPlayer)
        {
            this.ID_ = _ID;
            this.cities_ = new List<CCity>();
            this.characters_ = new List<CCharacter>();
            this.controlledByPlayer_ = _controlledByPlayer;
        }

        public void Update(int _gameTurn, CGameAIManager _gameAIManager)
        {
            if (this.controlledByPlayer_)
            {
            }
            else
            {
                foreach (CCity city in this.cities_)
                {
                    city.PushGameCommand(_gameAIManager.GetGameCommand(city.ID));
                }
            }

            foreach (CCity city in this.cities_)
            {
                city.Update(_gameTurn);
            }
        }

        public void AddCity(CCity _city)
        {
            bool canAddCity = true;
            foreach (CCity city in this.cities_)
            {
                if (city.Equals(_city))
                {
                    canAddCity = false;
                }
            }

            if (canAddCity)
            {
                this.cities_.Add(_city);
            }
        }

        public void RemoveCity(CCity _city)
        {
            this.cities_.Remove(_city);
        }

        public void AddCharacter(CCharacter _character)
        {
            bool canAddCharacter = true;
            foreach (CCharacter character in this.characters_)
            {
                if (character.Equals(_character))
                {
                    canAddCharacter = false;
                }
            }

            if (canAddCharacter)
            {
                this.characters_.Add(_character);
            }
        }

        public int ID
        {
            get
            {
                return this.ID_;
            }
        }

        public List<CCity> Cities
        {
            get
            {
                return this.cities_;
            }
        }

        public List<CCharacter> Characters
        {
            get
            {
                return this.characters_;
            }
        }
    }
}
