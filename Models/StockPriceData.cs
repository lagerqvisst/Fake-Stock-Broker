using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StockPriceData
    {
        public decimal C { get; set; } // Ändra typen till decimal
        public string T { get; set; }
        public decimal H { get; set; }
        public decimal L { get; set; }
        public decimal O { get; set; }
        public decimal V { get; set; }
        public decimal VW { get; set; }
    }
}
