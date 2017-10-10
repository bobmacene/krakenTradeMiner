namespace krakenTradeMiner
{
    public enum CurrencyPair { EthEur, BtcEur, LtcEur, LtcBtc, InvalidPair }

    public class SharedData
    {
        public bool IsFirstRun { get; set; } = true;
        public bool StopApp { get; set; } = false;
        public int Count { get; set; } = 0;
        public long Since { get; set; } = 1482576757925126325;

        public Logger Log = new Logger();
        public ApiCall Call = new ApiCall();
        public DataAccess Data = new DataAccess();
    }
}
