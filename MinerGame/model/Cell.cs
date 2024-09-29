using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGame
{
    internal struct Cell
    {
        public bool hasBomb { get; set; }
        public bool isMarked = false;
        public bool isOpen = false;
        public int bombsAround = 0;
        public string getContent()
        {
            if (this.isMarked) return "P";
            if (this.hasBomb) return "*";
            if (this.bombsAround > 0) return this.bombsAround.ToString();
            return "";
        }
    }
}
