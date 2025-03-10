using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class CertifyMst
    {
      [Key]
        public int Certify_ID { get; set; } // Key
        public string Certify_Type { get; set; } // Ex: 918, 920
    }
}
