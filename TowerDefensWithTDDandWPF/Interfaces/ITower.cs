using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefensWithTDDandWPF.Interfaces
{
    public interface ITower
    {
        void Build();
        void Upgrade();
        void FindEnemy();
        void AttackEnemy();
        void Repair();
    }
}
