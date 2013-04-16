using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;

using FliSan.GameObject;

namespace FliSan
{
    class GameMain
    {
        private CGame game_;

        static void Main(string[] args)
        {
            GameMain gMain = new GameMain();
            gMain.Start();
        }

        private GameMain()
        {
            game_ = new CGame();            
        }

        private void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "FliSan !!", Styles.Fullscreen);

            while (window.IsOpen())
            {
                window.DispatchEvents();

                window.Clear(Color.Black);
                Update();
                Render(window);
                window.Display();
            }
        }

        private void Update()
        {
        }

        private void Render(RenderWindow _window)
        {
        }
    }
}
