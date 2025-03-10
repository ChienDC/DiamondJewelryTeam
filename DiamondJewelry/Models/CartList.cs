using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DiamondJewelry.Models
{
    public class CartList
    {
      [Key]
        public int ID { get; set; } // Key
        public string Product_Name { get; set; }
        public decimal MRP { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
