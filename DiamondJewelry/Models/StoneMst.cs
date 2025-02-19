namespace DiamondJewelry.Models
{
    public class StoneMst
    {
        public string Style_Code { get; set; } // Khóa ngoại từ ItemMst
        public int StoneQlty_ID { get; set; } // Khóa ngoại từ StoneQltyMst
        public decimal Stone_Gm { get; set; }
        public int Stone_Pcs { get; set; }
        public decimal Stone_Crt { get; set; }
        public decimal Stone_Rate { get; set; }
        public decimal Stone_Amt { get; set; }
    }
}