using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiamondJewelry.Models;

public class ItemMst
{
  [Key] // Define as Primary Key
  public string Style_Code { get; set; }

  public int Pairs { get; set; }

  [ForeignKey("BrandMst")]
  public int Brand_ID { get; set; }

  public int Quantity { get; set; }

  [ForeignKey("CatMst")]
  public int Cat_ID { get; set; }

  public string Prod_Quality { get; set; }

  [ForeignKey("CertifyMst")]
  public int Certify_ID { get; set; }

  [ForeignKey("ProdMst")]
  public int Prod_ID { get; set; }

  [ForeignKey("GoldKrtMst")]
  public int GoldType_ID { get; set; }

  public decimal Gold_Wt { get; set; }
  public decimal Stone_Wt { get; set; }
  public decimal Net_Gold { get; set; }
  public decimal Tot_Gross_Wt { get; set; }
  public decimal MRP { get; set; }

  public string Img { get; set; }

  // 🔥 Navigation Properties (Table Relationship) - allow null
  public virtual BrandMst? BrandMst { get; set; }
  public virtual CatMst? CatMst { get; set; }
  public virtual CertifyMst? CertifyMst { get; set; }
  public virtual ProdMst? ProdMst { get; set; }
  public virtual GoldKrtMst? GoldKrtMst { get; set; }
}
