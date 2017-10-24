using System.ComponentModel.DataAnnotations;

namespace krakenTradeMiner.Models
{
    public class MaId
    {
        [Key]
        public int Id { get; set; }
        public int IdMa { get; set; }
    }
}
