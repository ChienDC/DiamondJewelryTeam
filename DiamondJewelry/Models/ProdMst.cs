using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class ProdMst
    {
      [Key]
        public int Prod_ID { get; set; } // Key
        public string Prod_Type { get; set; } // Ex: Ring,...
    }
}
