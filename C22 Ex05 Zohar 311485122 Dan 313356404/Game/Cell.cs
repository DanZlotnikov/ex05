using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Cell
    {
        public int value;
        public bool revelad = false;
        public bool resolved = false;
        public Player owner;

        public Cell(int value)
        {
            this.value = value;
        }
    }
}
