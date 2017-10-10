using System;
using System.Threading.Tasks;

namespace krakenTradeMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeData = new ProcessTradeData();
            var shared = new SharedData();

            try
            {
                var serverTime = string.Empty;
                shared.Log.AddServerTimeToLog(shared.Call, out serverTime);
                Console.WriteLine($"ServerTime: {serverTime}");

                var actions = new Action[]
                {
                    //()=> tradeData.CallApi(shared, CurrencyPair.EthEur),
                    ()=> tradeData.CallApi(shared, CurrencyPair.BtcEur),
                    //()=> tradeData.CallApi(shared, CurrencyPair.LtcEur),
                    //()=> tradeData.CallApi(shared, CurrencyPair.LtcBtc)
                };

                while (!shared.StopApp)
                {
                    foreach (var action in actions)
                    {
                        action.Invoke();
                        Console.WriteLine($"ApiCall Processed: {DateTime.Now}");
                        Task.Delay(10 * 1000).Wait();
                    }

                    //Task.Delay(60 * 60 * 1000).Wait();
                }

            }
            catch (Exception ex)
            {
                shared.Log.AddLogEvent(ex.ToString());
                shared.Log.PersistLog();
            }
        }
    }
}
