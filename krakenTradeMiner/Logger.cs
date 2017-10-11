using System;
using System.IO;

namespace krakenTradeMiner
{
    public class Logger
    {
        public string Log;
        public string LogPath = @"C:\Users\bob\Documents\KrakenDataMiner\Log";
        public string Filename;
        private string _serverTimeUrl = "https://api.kraken.com/0/public/Time";

        public Logger()
        {
            Log = DateTime.Now + ":    KRAKEN.DATA.MINER STARTED.\n\n";
            Filename = $"{DateTime.Now.ToString("yyyy.MM.dd_HHmmss")}_KrakenDataMiner.txt";
            LogPath = Path.Combine(LogPath, Filename);
        }

        public void AddServerTimeToLog(ApiCall api, out string serverTime)
        {
            var exception = string.Empty;
            serverTime = api.CallApi(_serverTimeUrl, out exception);
            var logLine = $"SERVERTIME: {serverTime}\n{DateTime.Now}:    Call Exception: {exception}";
            Log += $"\n{DateTime.Now}:    {logLine}\n";
        }

        public void AddLogEvent(string label)
        {
            Log += $"{DateTime.Now}:    {label}";
        }

        public void AddLogEvent(string label, string dataToLog)
        {
            Log += $"{DateTime.Now}:    {label} {dataToLog}\n";
        }

        public void PersistLog()
        {
            File.AppendAllText(LogPath, Log);
        }
    }

}
