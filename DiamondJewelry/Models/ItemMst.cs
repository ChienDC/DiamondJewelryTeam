namespace DiamondJewelry.Models
{
    public class ItemMst
    {
        public string Style_Code { get; set; } // Khóa chính
        public int Pairs { get; set; }
        public int Brand_ID { get; set; } 
        public int Quantity { get; set; }
        public int Cat_ID { get; set; }
        public string Prod_Quality { get; set; }
        public int Certify_ID { get; set; }
        public int Prod_ID { get; set; }
        public int GoldType_ID { get; set; }
        public decimal Gold_Wt { get; set; }
        public decimal Stone_Wt { get; set; }
        public decimal Net_Gold { get; set; }
        public decimal Tot_Gross_Wt { get; set; }
        public decimal MRP { get; set; }
    }
}