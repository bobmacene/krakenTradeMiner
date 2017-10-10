using System;

namespace krakenTradeMiner.Pairs
{
    public interface IPairPathsUrl
    {
        string OhlcJsonPath { get; }
        string OhlcCsvPath { get; }
        string OhlcUrl { get; }

        string TradeJsonPath { get; }
        string TradeCsvPath { get; }
        string TradeUrl { get; }
    }
    //public class LtcBtcPairPathsUrl : IPairPathsUrl
    //{
    //    public string OhlcUrl { get; set; } =
    //      "https://api.kraken.com/0/public/OHLC?pair=XLTCXXBT&amp;since=";
    //    public string OhlcCsvPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\LtcBtc\Csv\KrakenOHLC_LtcBtc.csv";
    //    public string OhlcJsonPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\LtcBtc\Json\KrakenOHLC_LtcBtc.json";
    //}

    //public class LtcEurPairPathUrl : IPairPathsUrl
    //{
    //    public string OhlcUrl { get; set; } =
    //        "https://api.kraken.com/0/public/OHLC?pair=XLTCZEUR&amp;since=";
    //    public string OhlcCsvPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\LtcEur\Csv\KrakenOHLC_LtcEur.csv";
    //    public string OhlcJsonPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\LtcEur\Json\KrakenOHLC_LtcEur.json";
    //}

    public class BtcEurPairPathUrl : IPairPathsUrl
    {
        public string OhlcUrl => "https://api.kraken.com/0/public/OHLC?pair=XXBTZEUR&since=";
        public string OhlcCsvPath => @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\BtcEur\Csv\KrakenOHLC_BtcEur.csv";
        public string OhlcJsonPath => @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\BtcEur\Json\KrakenOHLC_BtcEur.json";

        public string TradeUrl => "https://api.kraken.com/0/public/Trades?pair=XXBTZEUR&since=";
        public string TradeCsvPath => @"C:\Users\bob\Documents\KrakenDataMiner\Trades\BtcEur\Csv\KrakenTrade_BtcEur.csv";
        public string TradeJsonPath => @"C:\Users\bob\Documents\KrakenDataMiner\Trades\BtcEur\Json\KrakenTrade_BtcEur.json";
    }

    //public class EthEurPairPathUrl : IPairPathsUrl
    //{
    //    public string OhlcUrl { get; set; } =
    //        "https://api.kraken.com/0/public/OHLC?pair=XETHZEUR&amp;since=";
    //    public string OhlcCsvPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\EthEur\Csv\KrakenOHLC_EthEur.csv";
    //    public string OhlcJsonPath =>
    //        @"C:\Users\bob\Documents\KrakenDataMiner\OHLC\EthEur\Json\KrakenOHLC_EthEur.json";

    //}
}
