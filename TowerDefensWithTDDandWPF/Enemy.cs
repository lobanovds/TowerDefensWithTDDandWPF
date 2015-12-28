using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerDefensWithTDDandWPF
{
    public class Enemy
    {
        public event EventHandler dieEvent;
        protected int _level = 1;
        protected int _lifes = 1;
        protected double _speed = 0.01;
        protected int shield = 0;
        protected int _reward = 50;
        protected Point position;

        public Enemy()
        {
            position = new Point(0.00, 0.00);
        }

        public Enemy(Point pos){
            position = pos;
        }

        public Enemy(Point pos, int level)
        {
            position = pos;
            _level = level;
        }

        public Point Go() {
            position.X += _speed;
            return position;
        }

        public void Die() {
                dieEvent.Invoke(this, new EventArgs());
        }

        public void Create() { }

        public int GetDamage(int Damage) {
            _lifes -= Damage;
            if (_lifes> 0)
            {
                return _lifes; 
            }
            else 
            {
                _lifes = 0;
                Die();
                return 0;
            }
        }

        public int GetLifes()
        {
            return _lifes;
        }

        public int dropMoney()
        {
            return _reward;
        }
    }

    public class Turtle : Enemy
    {
        public Turtle(Point pos){
            _speed = 0.01;
            _lifes = 20;
            position = pos;
            _reward = 1;
        }

        public Turtle(Point pos, int level)
        {
            _level = level;
            _speed = 0.01*_level;
            _lifes = 20 + _level * 5;
            position = pos;
            _reward = 1;
        }
    }

    public class Runner : Enemy
    {
        public Runner(){}
        public Runner(Point pos){
            _speed = 1.00;
            _lifes = 30;
            position = pos;
            _reward = 7;
        }
    }
}
