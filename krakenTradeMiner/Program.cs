using krakenTradeMiner.Models;
using krakenTradeMiner.Pairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace krakenTradeMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DbQuery
            //using (var db = new KrakenTradeMinerContext())
            //{
            //    var last = db.Trades.Last().Time;

            //    var numberTrades = db.Trades.Last().Id;
            //}
            #endregion

            var shared = new SharedData();
            var pair = new BtcEurPairPathUrl();

            try
            {
                #region trdMiner
                //var tradeData = new ProcessTradeData();

                //var serverTime = string.Empty;
                //shared.Log.AddServerTimeToLog(shared.Call, out serverTime);
                //Console.WriteLine($"ServerTime: {serverTime}");

                //var actions = new Action[]
                //{
                //        //()=> tradeData.CallApi(shared, CurrencyPair.EthEur),
                //        ()=> tradeData.GetTrades(shared, CurrencyPair.BtcEur),
                //    //()=> tradeData.CallApi(shared, CurrencyPair.LtcEur),
                //    //()=> tradeData.CallApi(shared, CurrencyPair.LtcBtc)
                //};

                //while (!shared.StopApp)
                //{
                //    foreach (var action in actions)
                //    {
                //        action.Invoke();
                //        Console.WriteLine($"ApiCall Processed: {DateTime.Now}");
                //        Task.Delay(3750).Wait();
                //    }

                //    //Task.Delay(60 * 60 * 1000).Wait();
                //}
                #endregion

                #region processing
                var strtTime = new DateTime(2017, 1, 1, 0, 0, 0);
                var endTime = new DateTime(2017, 8, 20);
                var span = new TimeSpan(0, 5, 0);
                var intervals = new List<DateTime> { strtTime };

                var numberInstervals = (endTime - strtTime) / span;

                for (var v = 0; v < numberInstervals + 25; v++)
                {
                    intervals.Add(strtTime += span);
                }

                var maIds = new List<int>();

                using (var db = new KrakenTradeMinerContext())
                {
                    var timeIds = db.Trades.AsEnumerable().Select(x => new { x.Id, x.Time });

                    var innerCount = 0;

                    MaId maId = null;

                    foreach (var interval in intervals)
                    {
                        foreach (var trd in db.Trades)
                        {
                            db.DatabaseInfo.ElementAt(0).MaTradeCount++;

                            if (timeIds.ElementAt(innerCount++).Time <= interval) continue;
                            if (db.Trades.ElementAt(innerCount).Time == null) break;

                            maId = new MaId { IdMa = innerCount };
                            db.MaIds.Add(maId);
                            db.DatabaseInfo.ElementAt(0).MaIdCount++;

                            db.Trades.ElementAt(innerCount).IsMaTrade = true;
                            db.DatabaseInfo.ElementAt(0).MaTradeCount++;

                            goto outer;
                        }
                        outer: continue;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                shared.Log.AddLogEvent(ex.ToString());
                shared.Log.PersistLog();
            }
        }

    }
}
