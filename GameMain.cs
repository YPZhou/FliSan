﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            RenderWindow window = null;

            try
            {
                window = new RenderWindow(new VideoMode(800, 600), "FliSan !!", Styles.Fullscreen);

                while (window.IsOpen())
                {
                    window.DispatchEvents();

                    window.Clear(Color.Black);
                    Update();
                    Render(window);
                    window.Display();
                    int a = 0;
                    int b = 100 / a;
                }
            }
            catch (Exception e)
            {
                if (window != null)
                {
                    window.Close();
                }
                DateTime dt = System.DateTime.Now;
                String logPath = "CrashLog_" + dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "h" + dt.Minute + ".log";
                StreamWriter sw = new StreamWriter(new FileStream(logPath, FileMode.Create));

                sw.WriteLine("==================== Message ====================");
                sw.WriteLine(e.Message);
                sw.WriteLine("=================== StackTrace ==================");
                sw.WriteLine(e.StackTrace);

                sw.Close();               

                MessageBox.Show("游戏遇到严重错误，请提交游戏目录下的'" + logPath + "'。", "游戏错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
