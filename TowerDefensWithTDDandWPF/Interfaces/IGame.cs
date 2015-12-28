using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefensWithTDDandWPF.Interfaces
{
    public interface IGame
    {
        void Run();
        void Pause();
        void Quit();
    }
}
