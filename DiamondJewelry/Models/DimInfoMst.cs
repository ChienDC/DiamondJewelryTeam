namespace DiamondJewelry.Models
{
    public class DimInfoMst
    {
        public int DimID { get; set; } // Khóa chính
        public string DimType { get; set; }
        public string DimSubType { get; set; }
        public decimal DimCrt { get; set; }
        public decimal DimPrice { get; set; }
        public string DimImg { get; set; }
    }
}