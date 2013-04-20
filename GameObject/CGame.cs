using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CGame
    {
        private CMap map_;
        private List<CFaction> factions_;
        private List<CCity> cities_;
        private List<CCharacter> characters_;

        private int gameTurn_;

        public CGame()
        {
            this.map_ = new CMap();
            this.factions_ = new List<CFaction>();
            this.cities_ = new List<CCity>();
            this.characters_ = new List<CCharacter>();
        }

        public void CreateGame()
        {
        }

        public void LoadGame(String _path)
        {
        }

        public void SaveGame(String _path)
        {
        }

        public void Update()
        {
            foreach (CFaction faction in this.factions_)
            {
                faction.Update(this.gameTurn_);
            }

            this.gameTurn_++;
        }
    }
}
