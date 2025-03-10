using System.ComponentModel.DataAnnotations;

namespace DiamondJewelry.Models
{
    public class StoneQltyMst
    {
      [Key]
        public int StoneQlty_ID { get; set; } // Key
        public string StoneQlty { get; set; } // Ex: Ruby, Meena
    }
}
