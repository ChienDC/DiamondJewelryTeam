using Microsoft.EntityFrameworkCore;

namespace DiamondJewelry.Models
{
  [Keyless]
    public class DimMst
    {
        public int DimQlty_ID { get; set; } // Foriegn Key DimQltyMst
        public int DimSubType_ID { get; set; } // Foriegn Key từ DimQltySubMst
        public decimal Dim_Crt { get; set; }
        public int Dim_Pcs { get; set; }
        public decimal Dim_Gm { get; set; }
        public decimal Dim_Size { get; set; }
        public decimal Dim_Rate { get; set; }
        public decimal Dim_Amt { get; set; }
    }
}
