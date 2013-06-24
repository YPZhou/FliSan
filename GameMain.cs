using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using SFML.Window;
using SFML.Graphics;

using FliSan.GameObject;
using FliSan.GameUI;
using FliSan.GameAI;

namespace FliSan
{
    class GameMain
    {
        private CGame game_;
        private CGameUIManager gameUIManager_;
        private CGameAIManager gameAIManager_;

        static void Main(string[] args)
        {
            GameMain gMain = new GameMain();
            gMain.Initialize();
            gMain.Start();
        }

        private GameMain()
        {
        }

        private void Initialize()
        {
            gameUIManager_ = new CGameUIManager();
            gameAIManager_ = new CGameAIManager();
            gameUIManager_.AddUI(new CUIMapRenderer(this.game_));

            game_ = new CGame(this.gameAIManager_);
            game_.CreateGame(10, 10);
            StreamWriter sw = new StreamWriter(new FileStream("gameMap.txt", FileMode.Create));
            sw.Write(game_.ToString());
            sw.Close();

            CArmy army1 = new CArmy();
            army1.Faction = game_.GetFactionByIndex(0);
            army1.City = army1.Faction.Cities[0];
            army1.City.CityDefence = 200;
            army1.Status = 0;
            CTroop troop1 = new CTroop();
            troop1.Character = army1.Faction.Characters[0];
            troop1.Faction = army1.Faction;
            troop1.Soldier = 120;
            troop1.Morale = 100;
            troop1.InjuredSoldier = 0;
            CTroop troop2 = new CTroop();
            troop2.Character = army1.Faction.Characters[1];
            troop2.Faction = army1.Faction;
            troop2.Soldier = 130;
            troop2.Morale = 100;
            troop2.InjuredSoldier = 0;
            CTroop troop3 = new CTroop();
            troop3.Character = army1.Faction.Characters[2];
            troop3.Faction = army1.Faction;
            troop3.Soldier = 150;
            troop3.Morale = 100;
            troop3.InjuredSoldier = 0;
            army1.AddTroop(troop1);
            army1.AddTroop(troop2);
            army1.AddTroop(troop3);

            CArmy army2 = new CArmy();
            army2.Faction = game_.GetFactionByIndex(1);
            army2.City = army2.Faction.Cities[0];
            army2.Status = 0;
            CTroop troop4 = new CTroop();
            troop4.Character = army2.Faction.Characters[0];
            troop4.Faction = army2.Faction;
            troop4.Soldier = 500;
            troop4.Morale = 100;
            troop4.InjuredSoldier = 0;
            CTroop troop5 = new CTroop();
            troop5.Character = army2.Faction.Characters[1];
            troop5.Faction = army2.Faction;
            troop5.Soldier = 500;
            troop5.Morale = 100;
            troop5.InjuredSoldier = 0;
            CTroop troop6 = new CTroop();
            troop6.Character = army2.Faction.Characters[2];
            troop6.Faction = army2.Faction;
            troop6.Soldier = 500;
            troop6.Morale = 100;
            troop6.InjuredSoldier = 0;
            army2.AddTroop(troop4);
            army2.AddTroop(troop5);
            army2.AddTroop(troop6);

            CBattle battle = new CBattle();
            battle.AddArmy(army1);
            battle.AddArmy(army2);

            sw = new StreamWriter(new FileStream("gameBattle.txt", FileMode.Create));          
            while (!battle.IsBattleEnd)
            {
                sw.WriteLine("========== 回合 ==========");
                sw.WriteLine(battle.ToString());
                battle.Update();
            }
            sw.WriteLine("========== 回合 ==========");
            sw.WriteLine(battle.ToString());
            sw.Close();
        }

        private void Start()
        {
            RenderWindow window = null;

            try
            {
                window = new RenderWindow(new VideoMode(800, 600), "FliSan !!", Styles.Fullscreen);

                while (window.IsOpen())
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                    {
                        window.Close();
                    }

                    window.DispatchEvents();

                    window.Clear(Color.Black);
                    Update();
                    Render(window);
                    window.Display();
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
            this.gameUIManager_.Update(this.game_);
            this.gameAIManager_.Update(this.game_); 
            this.game_.Update();                      
        }

        private void Render(RenderWindow _window)
        {
            this.gameUIManager_.Render(_window);
        }
    }
}
