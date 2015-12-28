using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefensWithTDDandWPF.Interfaces
{
    public interface IEnemy
    {
        void GetDamage(int lifes);
        int Die();
        void Create();
        void Go();
        void Heal(int lifes);
    }
}
