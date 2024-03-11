using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Models
    {
        public class StockPriceResponse
        {
            public bool Adjusted { get; set; }
            public int QueryCount { get; set; }
            public string RequestId { get; set; }
            public List<StockPriceData> Results { get; set; }
            public int ResultsCount { get; set; }
            public string Status { get; set; }
            public string Ticker { get; set; }
        }
    }
