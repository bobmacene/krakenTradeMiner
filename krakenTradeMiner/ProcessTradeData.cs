using krakenTradeMiner.JsonModel;
using krakenTradeMiner.Models;
using krakenTradeMiner.Pairs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace krakenTradeMiner
{
    public class ProcessTradeData
    {
        public void GetTrades(SharedData shared, CurrencyPair pair)
        {
            var pairData = new PairFactory().GetPairData(pair);
            DateTime stopDate = new DateTime();

            using (var db = new KrakenTradeMinerContext())
            {
                if(db.Trades.Any()) shared.Since = db.Trades.Last().LastTradeId;
                shared.Log.AddLogEvent("Last Trade Number: ", $"{shared.Since}\n");

                var _url = pairData.TradeUrl + shared.Since;
                shared.Log.AddLogEvent("Api Call Path:", _url.ToString());

                var _trades = ApiCallGetTrades(shared, _url, pair);

                if (_trades != null)
                {
                    foreach (var trd in _trades)
                    {
                        db.Trades.Add(trd);
                        db.SaveChanges();
                    }
                    stopDate = _trades.Last().Time;
                }                
            }
               
            shared.Log.AddLogEvent($"Run {++shared.Count} Finished\n\n");
            shared.Log.PersistLog();
            shared.Log.Log = string.Empty;

            if (stopDate >= new DateTime(2016, 12, 31))
            {
                shared.Log.AddLogEvent("\n\n2017 reached, data for 2016 concluded\n");
                shared.Log.PersistLog();
                Environment.Exit(0);
            }
        }

        private List<Trade> ApiCallGetTrades(SharedData shared, string url, CurrencyPair pair)
        {
            var _apiCallException = string.Empty;

            var json = shared.Call.CallApi(url, out _apiCallException);

            var jsonHasErrors = json.Count() < 300;
            var apiCallFailed = _apiCallException != string.Empty;

            if (jsonHasErrors || apiCallFailed)
            {
                if (apiCallFailed)
                {
                    shared.Log.AddLogEvent($"ApiCall failed: {_apiCallException}\n");
                }
                else
                {
                    shared.Log.AddLogEvent($"Incorrect json from ApiCall: {json} aborting this run and retrying ApiCall\n");
                }
                return null;
            }

            return ProcessJsonModel(shared, json, pair);
        }

        public List<Trade> ProcessJsonModel(SharedData shared, string json, CurrencyPair pair)
        {
            var trades = new List<Trade>();
            string last;

            var newBtcEurTrades = shared.JsonData.Deserialise<BtcEurTrades>(json);
            last = newBtcEurTrades.Result.Last;

            foreach (var trd in newBtcEurTrades.Result.XXBTZEUR)
            {
                trades.Add(new Trade(trd, last, pair));
            }
            return trades;
        }

    }
}
