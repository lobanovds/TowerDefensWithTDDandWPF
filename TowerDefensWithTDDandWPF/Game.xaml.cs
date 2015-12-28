using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TowerDefensWithTDDandWPF
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public DispatcherTimer Timer;
        public static string GameState = "Run";
        public MainWindow mW;
        public int tickCounter=0;
        public Game()
        {
            InitializeComponent();
            mW = new MainWindow();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(10000);
            Timer.Tick += Timer_Tick;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            switch (GameState)
            {
                case "Run": 
                    MakeStep(sender);
                    if (tickCounter == 300)
                    {
                        AddCashForTime();
                        tickCounter = 0;
                    }
                    else tickCounter++;
                    break;
                case "End": Close(); break;
                default: break;
            }
        }

        public void StartGameButtonClick(object sender, RoutedEventArgs e)
        {
            StartGame((object)null);
        }

        public void MakeStep(object timer)
        {
               mW.Step(timer);
        }

        public void AddCashForTime(int defaultCash=30)
        {
            mW.newPlayer.GetReward(defaultCash);
        }

        public void StartGame(object e)
        {
            Hide();
            Timer.Start();
            mW.Show();
        }

        
    }
}
