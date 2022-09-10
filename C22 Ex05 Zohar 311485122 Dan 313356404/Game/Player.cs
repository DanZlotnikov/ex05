using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; } = 0;

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
