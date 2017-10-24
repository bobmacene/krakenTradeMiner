namespace krakenTradeMiner
{
    public enum CurrencyPair { EthEur, BtcEur, LtcEur, LtcBtc, InvalidPair }

    public class SharedData
    {
        public bool StopApp { get; set; } = false;
        public int Count { get; set; } = 0;
        public long Since { get; set; } = 1451566757925126325;

        public Logger Log = new Logger();
        public ApiCall Call = new ApiCall();
        public JsonDataAccess JsonData = new JsonDataAccess();
    }
}
