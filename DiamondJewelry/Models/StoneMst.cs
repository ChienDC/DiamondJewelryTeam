namespace DiamondJewelry.Models
{
    public class StoneMst
    {
        public string Style_Code { get; set; } // Foriegn Key ItemMst
        public int StoneQlty_ID { get; set; } // Foriegn Key StoneQltyMst
        public decimal Stone_Gm { get; set; }
        public int Stone_Pcs { get; set; }
        public decimal Stone_Crt { get; set; }
        public decimal Stone_Rate { get; set; }
        public decimal Stone_Amt { get; set; }
    }
}
