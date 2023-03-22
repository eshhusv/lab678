using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab678
{
    internal class Monitor
    {
        public  string Name { get; set; }
        public int Diagonal { get; set; }
        public int Price { get; set; }
        public Monitor(string name, int diagonal, int price)
        {
            Name = name;
            Diagonal = diagonal;
            Price = price;
        }
    }
}
