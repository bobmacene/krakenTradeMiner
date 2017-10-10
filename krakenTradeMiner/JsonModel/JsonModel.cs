using System.Collections.Generic;

namespace krakenTradeMiner.JsonModel
{
    public class BtcEurTrades
    {
        public string[] Error { get; set; }
        public BtcEurTradeData Result { get; set; }
    }

    public class BtcEurTradeData
    {
        public List<string[]> XXBTZEUR { get; set; }
        public string Last { get; set; }
    }
}
