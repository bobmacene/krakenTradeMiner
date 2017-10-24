using System.ComponentModel.DataAnnotations;

namespace krakenTradeMiner.Models
{
    public class DatabaseInfo
    {
        [Key]
        public int Id { get; set; }
        public int MaIdCount { get; set; } = 0;
        public int MaTradeCount { get; set; } = 0;
        public int DbTradeCount { get; set; } = 0;
    }
}
