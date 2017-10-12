using krakenTradeMiner.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace krakenTradeMiner.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUrl()
        {
            var url = new Uri("https://api.kraken.com/0/public/Trades?pair=XBTEUR&amp;since=");

            long since = 1482576757925126325;

            var newUrl = new Uri(url.ToString() + since);
            var path = url.ToString() + since;

            Assert.AreEqual(newUrl.ToString(), path);
        }

        [TestMethod]
        public void TestUrlApiCall()
        {
            var path = "https://api.kraken.com/0/public/Trades?pair=XXBTZEUR&since=" + 1482576757925126325;
            var api = new ApiCall();
            var exception = string.Empty;

            var json = api.CallApi(path, out exception);

            var process = new ProcessTradeData();
            var trades = process.ProcessJsonModel(new SharedData(), json, CurrencyPair.BtcEur);

            Assert.AreEqual(trades[0].Price, 863.73500M);
        }

        [TestMethod]
        public void TestGetAllDbItems()
        {
            using (var db = new KrakenTradeMinerContext())
            {
                var last = db.Trades.ToList().Last();
                
                var numberTrades = db.Trades.Count();

                Assert.IsNotNull(last.LastTradeId);
            }
        }
    }
}
