using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace krakenTradeMiner.Models
{
    [Table("trades")]
    public class Trade
    {
        [Key]
        public int Id { get; set; }
        public decimal UnixTime { get; set; }
        public DateTime Time { get; set; }
        public string Pair { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public string Direction { get; set; }
        public string Type { get; set; }
        public string Miscellaneous { get; set; }
        public long LastTradeId { get; set; }

        //public Trade() { }

        public Trade(string[] jsonTrds, string last, CurrencyPair pair)
        {
            UnixTime = Convert.ToDecimal(jsonTrds[2]);
            Time = GetTime(Convert.ToDouble(jsonTrds[2]));
            Pair = pair.ToString();
            Price = Convert.ToDecimal(jsonTrds[0]);
            Volume = Convert.ToDecimal(jsonTrds[1]);
            Direction = jsonTrds[3];
            Type = jsonTrds[4];
            Miscellaneous = jsonTrds[5];
            LastTradeId = Convert.ToInt64(last);
        }

        public override string ToString()
        {
            return $"Unixtime:, {UnixTime}, Time:, {Time}, Pair:, {Pair}, Price:, {Price}, Volume:, {Volume},"+
                   $"Direction:, {Direction}, Type:, {Type}, Miscellaneous:, {Miscellaneous}, LastTradeId:, {LastTradeId}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Convert.ToInt32(Direction);
                result = (result * 397) ^ Convert.ToInt32(Price);
                result = (result * 397) ^ Convert.ToInt32(Volume);
                result = (result * 397) ^ Convert.ToInt32(Time);
                return result;
            }
        }

        private static DateTime GetTime(double msFrmUnix)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(msFrmUnix).ToLocalTime();
            return dtDateTime;
        }

    }
}
