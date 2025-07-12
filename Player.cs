using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaTrekk
{
   
    public class Player
    {
        public string Name;
        public int Position;

        public Player(string name)
        {
            Name = name;
            Position = 0;
        }
    }
}
