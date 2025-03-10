using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class JewelTypeMst
    {
      [Key]
        public int ID { get; set; } // Key
        public string Jewellery_Type { get; set; }
    }
}
