using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class GoldKrtMst
    {
      [Key]
        public int GoldType_ID { get; set; } // Key
        public string Gold_Crt { get; set; } // Ex: 18K, 22K
    }
}
