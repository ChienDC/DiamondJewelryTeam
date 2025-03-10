using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class DimInfoMst
    {
      [Key]
        public int DimID { get; set; } // Key
        public string DimType { get; set; }
        public string DimSubType { get; set; }
        public decimal DimCrt { get; set; }
        public decimal DimPrice { get; set; }
        public string DimImg { get; set; }
    }
}
