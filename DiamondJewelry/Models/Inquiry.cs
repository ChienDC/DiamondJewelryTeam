namespace DiamondJewelry.Models
{
    public class Inquiry
    {
        public int ID { get; set; } // Khóa chính
        public string Name { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string EmailID { get; set; }
        public string Comment { get; set; }
        public DateTime CDate { get; set; }
    }
}