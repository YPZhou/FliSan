using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FliSan.GameObject;

using SFML.Graphics;

namespace FliSan.GameUI
{
    class CUIMapRenderer : IGameUI
    {
        private Font font_;
        private Text text_;

        public CUIMapRenderer(GameObject.CGame _game)
        {
            this.font_ = new Font("cn_font.ttf");
            this.text_ = new Text("刘关张", this.font_);
        }

        public void Update(GameObject.CGame _game)
        {
            //throw new NotImplementedException();
        }

        public void Render(RenderWindow _window)
        {
            _window.Draw(this.text_);
        }
    }
}
