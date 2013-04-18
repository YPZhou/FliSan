using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FliSan.GameObject
{
    class CFaction
    {
        private List<CCity> cities_;
        private List<CCharacter> characters_;        

        private bool controlledByPlayer_;

        public CFaction(bool _controlledByPlayer)
        {
            this.controlledByPlayer_ = _controlledByPlayer;
        }

        public void Update(int _gameTurn)
        {
            if (this.controlledByPlayer_)
            {
            }
            else
            {
            }

            foreach (CCity city in this.cities_)
            {
                city.Update(_gameTurn);
            }
        }
    }
}
