using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;

using SFML.Window;
using SFML.Graphics;

namespace FliSan.GameUI
{
    class CGameUIManager
    {
        private List<IGameUI> gameUIs_;

        public CGameUIManager()
        {
            this.gameUIs_ = new List<IGameUI>();
        }

        public void Update(CGame _game)
        {
            foreach (IGameUI gameUI in this.gameUIs_)
            {
                gameUI.Update(_game);
            }
        }

        public void Render(RenderWindow _window)
        {
            foreach (IGameUI gameUI in this.gameUIs_)
            {
                gameUI.Render(_window);
            }
        }

        public void AddUI(IGameUI _gameUI)
        {
            if (_gameUI != null)
            {
                this.gameUIs_.Add(_gameUI);
            }
        }
    }
}
