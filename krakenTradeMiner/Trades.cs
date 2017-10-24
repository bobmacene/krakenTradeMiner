using System;
using System.Collections.Generic;

namespace krakenTradeMiner
{
    public partial class Trades
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public long LastTradeId { get; set; }
        public string Miscellaneous { get; set; }
        public string Pair { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public decimal UnixTime { get; set; }
        public decimal Volume { get; set; }
    }
}
