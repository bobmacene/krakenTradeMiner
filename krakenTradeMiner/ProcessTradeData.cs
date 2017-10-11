using krakenTradeMiner.JsonModel;
using krakenTradeMiner.Models;
using krakenTradeMiner.Pairs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace krakenTradeMiner
{

    public class ProcessTradeData
    {

        public void CallApi(SharedData shared, CurrencyPair pair)
        {
            var pairData = new PairFactory().GetPairData(pair);
            shared.Log.AddLogEvent("JsonTradeFile Path:", pairData.TradeJsonPath);
            shared.Log.AddLogEvent("CsvTradeFile Path:", pairData.TradeCsvPath);

            if (shared.IsFirstRun)
            {
                shared.Since = GetLastTradeNumber(pairData.TradeJsonPath, shared);
                shared.Log.AddLogEvent("Last Trade Number: ", $"{shared.Since}\n");
                shared.IsFirstRun = false;
            }

            var _url = pairData.TradeUrl + shared.Since;
            shared.Log.AddLogEvent("Api Call Path:", _url.ToString());

            GetTrades(shared, pair, _url, pairData.TradeJsonPath, pairData.TradeCsvPath, out long _since);

            shared.Since = _since;

            shared.Log.AddLogEvent($"Run {++shared.Count} Finished\n\n");
            shared.Log.PersistLog();
            shared.Log.Log = string.Empty;
        }

        public void GetTrades(SharedData shared, CurrencyPair pair, string url, string jsonPath, string csvPath, out long since)
        {
            var latestTrades = GetNewTrades(shared, url, pair);

            if (latestTrades == null)
            {
                since = shared.Since;
                return;
            }

            var currentTrades = new FileInfo(jsonPath).Exists ? 
                shared.Data.Deserialise<List<Trade>>(File.ReadAllText(jsonPath)) : null;

            if (currentTrades == null)
            {
                File.AppendAllLines(csvPath, latestTrades.Select(x => x.ToString()).ToArray());
                shared.Data.WriteTrades(latestTrades, jsonPath);
                shared.Log.AddLogEvent("Trades Saved To: ", jsonPath);
            }
            else
            {
                if (latestTrades.Any())
                {
                    currentTrades.AddRange(latestTrades);
                    shared.Data.OverWriteExistingTrades(currentTrades, jsonPath);
                    File.AppendAllLines(csvPath, latestTrades.Select(x => x.ToString()).ToArray());
                    shared.Log.AddLogEvent("Trades Saved To: ", jsonPath);
                }
            }

            since = latestTrades.Last().LastTradeId;
            shared.Log.AddLogEvent("Number of new trds added: ", latestTrades.Count.ToString());
        }

        private List<Trade> GetNewTrades(SharedData shared, string url, CurrencyPair pair)
        {
            var _apiCallException = string.Empty;

            var json = shared.Call.CallApi(url, out _apiCallException);

            var jsonHasErrors = json.Count() < 300;
            var apiCallFailed = _apiCallException != string.Empty;

            if (jsonHasErrors || apiCallFailed)
            {
                if (jsonHasErrors) shared.Log.AddLogEvent($"Incorrect json from ApiCall: {json} aborting this run and retrying ApiCall\n");
                else shared.Log.AddLogEvent($"ApiCall failed: {_apiCallException}\n");
                return null;
            }

            return ProcessJsonModel(shared, json, pair);
        }

        public List<Trade> ProcessJsonModel(SharedData shared, string json, CurrencyPair pair)
        {
            var trades = new List<Trade>();
            string last;

            var newBtcEurTrades = shared.Data.Deserialise<BtcEurTrades>(json);
            last = newBtcEurTrades.Result.Last;

            foreach (var trd in newBtcEurTrades.Result.XXBTZEUR)
            {
                trades.Add(new Trade(trd, last, pair));
            }
            return trades;
        }

        private long GetLastTradeNumber(string path, SharedData shared)
        {
            List<Trade> trades = null;

            if (File.Exists(path)) trades = JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(path));

            return trades == null || trades.Count() == 0 ? shared.Since : trades.Last().LastTradeId;
        }
    }
}
