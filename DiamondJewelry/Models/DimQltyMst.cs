using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiamondJewelry.Models
{
  public class DimQltyMst
  {
    [Key] // Vẫn là khóa chính
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // Not auto increasing
    public int DimQlty_ID { get; set; }

    [Required]
    public string DimQlty { get; set; } // Ex: AD, FD, VVS
  }
}
