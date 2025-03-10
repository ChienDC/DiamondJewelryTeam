using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiamondJewelry.Models
{
    public class DimQltySubMst
    {
      [Key] // Vẫn là khóa chính
      [DatabaseGenerated(DatabaseGeneratedOption.None)] // Not auto increasing
        public int DimSubType_ID { get; set; } // Key

      [Required]
      public string DimQlty { get; set; }
    }
}
