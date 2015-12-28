using System;
using System.ComponentModel;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string GameState = "Run";

        public static int squareSize = 25;
        public static int levelWidth = squareSize * 20;
        public static int levelHeight = squareSize * 21;

        public int startPoitionY = levelHeight / 2;         //
        public int startPoitionX = 0;                       // TODO: Need to optimize
        Point StartPoint = new Point(0, levelHeight / 2);   //
        
        public List<Enemy> Enemies = new List<Enemy>();
        public List<Button> EnemyButtons = new List<Button>();
        
        public Player newPlayer;        
        // ^^^^----- here big problem too many vars

        public MainWindow()
        {
            InitializeComponent();
            SetMapSize();
            Enemy.Width = Enemy.Height = squareSize;
            newPlayer = new Player("Dima");
            newPlayer.updateBalance += newPlayer_updateBalance;
        }


        public void SetMapSize()
        {
            Width = levelWidth + 10;
            Height = levelHeight + 131;
            CanvasMap.Width = levelWidth;
            CanvasMap.Height = levelHeight;
        }

        public void SetPosition(UIElement Element, Point position)
        {
            Element.SetValue(LeftProperty, position.X);
            Element.SetValue(TopProperty, position.Y);
        }

        public void Step(object timer)
        {
            for (int i = 0; i < Enemies.Count; i++)
                {
                    Point newPosition = Enemies[i].Go();
                    SetPosition(EnemyButtons[i], newPosition);
                }
        }

        private void Pause_Click_1(object sender, RoutedEventArgs e)
        {
            Game.GameState = Game.GameState == "Pause" ? "Run" : "Pause";
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            Game.GameState = "End";
        }

        private void newEnemy_Click_1(object sender, RoutedEventArgs e)
        {
            CreateNewEnemy();
        }

        private void CreateNewEnemy()
        {
            Button btn = new Button();
            btn.Content = "Enemy Button " + Enemies.Count;
            CanvasMap.Children.Add(btn);
            btn.SetValue(LeftProperty, StartPoint.X);
            btn.SetValue(TopProperty, StartPoint.Y);
            EnemyButtons.Add(btn);
            
            Enemy bot;
            if (Enemies.Count % 2 == 0)
                bot = new Turtle(StartPoint, Enemies.Count + 1);
            else
                bot = new Runner(StartPoint);
            bot.dieEvent += bot_dieEvent;
            Enemies.Add(bot);

            btn.Content = bot.GetLifes();
        }

        void bot_dieEvent(object sender, EventArgs e)
        {
            newPlayer.GetReward(((Enemy)sender).dropMoney());
        }


        void newPlayer_updateBalance(object sender, EventArgs e)
        {
            Cash.Content = ((Player)sender).ShowBalance() + "$";
        }

        private void Enemy_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Enemies.Count; i++)
                {
                    Enemies[i].GetDamage(10);
                    if (Enemies[i].GetLifes() > 0)
                    {
                        EnemyButtons[i].Content = Enemies[i].GetLifes();
                    }
                    else
                    {
                        CanvasMap.Children.Remove(EnemyButtons[i]);
                        EnemyButtons.Remove(EnemyButtons[i]);
                        Enemies.Remove(Enemies[i]);              
                    }
                }
        }
       
    }
}
