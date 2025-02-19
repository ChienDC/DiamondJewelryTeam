namespace DiamondJewelry.Models
{
    public class DimMst
    {
        public string Style_Code { get; set; } // Khóa ngoại từ ItemMst
        public int DimQlty_ID { get; set; } // Khóa ngoại từ DimQltyMst
        public int DimSubType_ID { get; set; } // Khóa ngoại từ DimQltySubMst
        public decimal Dim_Crt { get; set; }
        public int Dim_Pcs { get; set; }
        public decimal Dim_Gm { get; set; }
        public decimal Dim_Size { get; set; }
        public decimal Dim_Rate { get; set; }
        public decimal Dim_Amt { get; set; }
    }
}