using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefensWithTDDandWPF.Interfaces;

namespace TowerDefensWithTDDandWPF
{
    public class Player : IPlayer
    {
        public event EventHandler updateBalance;
        private int _money =0;
        private string _playerName = "";

        public Player()
        { 
            
        }

        public Player(string newName)
        {
            _playerName = newName;
        }

        public void GetReward(int moneyToAdd)
        {
            _money += moneyToAdd; 
            updateBalance.Invoke(this, new EventArgs());
        }

        public int ShowBalance()
        {
            return _money;
        }
    }
}
