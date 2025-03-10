using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class Inquiry
    {
      [Key]
        public int ID { get; set; } // Key
        public string Name { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string EmailID { get; set; }
        public string Comment { get; set; }
        public DateTime CDate { get; set; }
    }
}
