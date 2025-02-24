using DiamondJewelry.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Bogus;

namespace DiamondJewelry.Data;

public class DbInitializer
{
  public static void Seed(JewelryDbContext context)
  {
    context.Database.EnsureCreated();

    var random = new Random();

    if (!context.Brands.Any())
    {
      var brands = new Faker<BrandMst>()
        .RuleFor(b => b.Brand_Type, f => f.Company.CompanyName())  // Không cần thêm Brand_ID vì nó là Identity
        .Generate(20);
      context.Brands.AddRange(brands);
    }

    if (!context.Categories.Any())
    {
      var categories = new Faker<CatMst>()
        .RuleFor(c => c.Cat_Name, f => f.Commerce.Categories(1)[0])  // Không cần thêm Cat_ID vì nó là Identity
        .Generate(20);
      context.Categories.AddRange(categories);
    }

    if (!context.Users.Any())
    {
      var users = new Faker<UserRegMst>()
        .RuleFor(u => u.Address, f => f.Address.FullAddress())
        .RuleFor(u => u.City, f => f.Address.City())
        .RuleFor(u => u.Dob, f => f.Date.Past(30))
        .RuleFor(u => u.EmailID, f => f.Internet.Email())
        .RuleFor(u => u.MobNo, f => f.Phone.PhoneNumber())
        .RuleFor(u => u.Password, f => f.Internet.Password())
        .RuleFor(u => u.State, f => f.Address.State())
        .RuleFor(u => u.UserFname, f => f.Name.FirstName())
        .RuleFor(u => u.UserLname, f => f.Name.LastName())
        .Generate(20);
      context.Users.AddRange(users);
    }

    if (!context.Categories.Any())
    {
      var categories = new Faker<CatMst>()
        .RuleFor(c => c.Cat_Name, f => f.Commerce.Department())
        .Generate(20);
      context.Categories.AddRange(categories);
      context.SaveChanges();
      Console.WriteLine("Thêm dữ liệu cho bảng DiamondQualities thành công!");
    }

    if (!context.DiamondQualities.Any())
    {
      // Giả sử bạn muốn 5 loại chất lượng
      var diamondQualities = new Faker<DimQltyMst>()
        .RuleFor(q => q.DimQlty, f => f.PickRandom("AD", "FD", "VVS1", "VVS2", "VS1"))
        .Generate(5);
      context.DiamondQualities.AddRange(diamondQualities);
      context.SaveChanges();
      Console.WriteLine("Thêm dữ liệu cho bảng DiamondQualities thành công!");
    }

    if (!context.DiamondSubQualities.Any())
    {
      var diamondQualitiesSub = new Faker<DimQltySubMst>()
        .RuleFor(q => q.DimQlty, f => f.PickRandom("AD", "FD", "VVS1", "VVS2", "VS1", "VS2"))
        .Generate(20);
      context.DiamondSubQualities.AddRange(diamondQualitiesSub);
      context.SaveChanges();
      Console.WriteLine("Thêm dữ liệu cho bảng DiamondQualities thành công!");
    }

    if (!context.Certifications.Any())
    {
      var certifications = new Faker<CertifyMst>()
        .RuleFor(c => c.Certify_Type, f => f.Random.Number(900, 999).ToString())
        .Generate(20);
      context.Certifications.AddRange(certifications);
      context.SaveChanges();
    }

    if (!context.StoneQualities.Any())
    {
      var stoneQualities = new Faker<StoneQltyMst>()
        .RuleFor(s => s.StoneQlty, f => f.PickRandom("Ruby", "Meena", "Emerald", "Sapphire"))
        .Generate(20);
      context.StoneQualities.AddRange(stoneQualities);
      context.SaveChanges();
    }

    if (!context.Products.Any())
    {
      var products = new Faker<ProdMst>()
        .RuleFor(p => p.Prod_Type, f => f.PickRandom("Nhẫn", "Dây chuyền", "Bông tai", "Lắc tay"))
        .Generate(20);
      context.Products.AddRange(products);
      context.SaveChanges();
    }

    if (!context.GoldCarats.Any())
    {
      var goldTypes = new Faker<GoldKrtMst>()
        .RuleFor(g => g.Gold_Crt, f => f.PickRandom("18K", "22K", "24K"))
        .Generate(20);
      context.GoldCarats.AddRange(goldTypes);
      context.SaveChanges();
    }

    if (!context.Inquiries.Any())
    {
      var inquiries = new Faker<Inquiry>()
        .RuleFor(i => i.Name, f => f.Name.FullName())
        .RuleFor(i => i.City, f => f.Address.City())
        .RuleFor(i => i.Contact, f => f.Phone.PhoneNumber())
        .RuleFor(i => i.EmailID, f => f.Internet.Email())
        .RuleFor(i => i.Comment, f => f.Lorem.Sentence())
        .RuleFor(i => i.CDate, f => f.Date.Past(1))
        .Generate(20);
      context.Inquiries.AddRange(inquiries);
      context.SaveChanges();
    }

    if (!context.JewelTypes.Any())
    {
      var jewelTypes = new Faker<JewelTypeMst>()
        .RuleFor(j => j.Jewellery_Type, f => f.PickRandom("Ring", "Necklace", "Bracelet", "Earrings"))
        .Generate(20);
      context.JewelTypes.AddRange(jewelTypes);
      context.SaveChanges();
    }

    if (!context.DiamondInfos.Any())
    {
      var dimInfos = new Faker<DimInfoMst>()
        .RuleFor(d => d.DimType, f => f.Commerce.ProductMaterial())
        .RuleFor(d => d.DimSubType, f => f.Commerce.ProductName())
        .RuleFor(d => d.DimCrt, f => f.Random.Decimal(0.1m, 5.0m))
        .RuleFor(d => d.DimPrice, f => f.Random.Decimal(100, 10000))
        .RuleFor(d => d.DimImg, f => f.Internet.Url())
        .Generate(20);
      context.DiamondInfos.AddRange(dimInfos);
      context.SaveChanges();
    }

    if (!context.CartLists.Any())
    {
      var cartLists = new Faker<CartList>()
        .RuleFor(c => c.Product_Name, f => f.Commerce.ProductName())
        .RuleFor(c => c.MRP, f => f.Random.Decimal(100, 5000))
        .Generate(20);
      context.CartLists.AddRange(cartLists);
      context.SaveChanges();
    }

    var validBrandIds = context.Brands.Select(b => b.Brand_ID).ToList();
    var validDiamondSubQualitiIds = context.DiamondSubQualities.Select(dsq => dsq.DimSubType_ID).ToList();
    var validCertifyIds = context.Certifications.Select(cf => cf.Certify_ID).ToList();
    var validGoldTypeIds = context.GoldCarats.Select(g => g.GoldType_ID).ToList();
    var validCategorieIds = context.Categories.Select(cg => cg.Cat_ID).ToList();
    var validProductIds = context.Products.Select(pr => pr.Prod_ID).ToList();
    var validStoneQualitieIds = context.StoneQualities.Select(sq => sq.StoneQlty_ID).ToList();
    var validDiamondQualitieIds = context.DiamondQualities.Select(dq => dq.DimQlty_ID).ToList();






    if (!context.Items.Any())
    {
      var items = new Faker<ItemMst>()
        .RuleFor(i => i.Style_Code, f => $"D{f.UniqueIndex + 100}")
        .RuleFor(i => i.Brand_ID, f => f.PickRandom(validBrandIds))
        .RuleFor(i => i.Cat_ID, f => f.PickRandom(validCategorieIds))
        .RuleFor(i => i.Certify_ID, f => f.PickRandom(validCertifyIds))
        .RuleFor(i => i.GoldType_ID, f => f.PickRandom(validGoldTypeIds))
        .RuleFor(i => i.Gold_Wt, f => f.Random.Decimal(0.1m, 50m))
        .RuleFor(i => i.MRP, f => f.Random.Decimal(1000, 50000))
        .RuleFor(i => i.Net_Gold, f => f.Random.Decimal(0.1m, 50m))
        .RuleFor(i => i.Pairs, f => f.Random.Number(1, 5))
        .RuleFor(i => i.Prod_ID, f => f.PickRandom(validProductIds))
        // Cung cấp giá trị không null cho Prod_Quality (ví dụ "A", "B", "C")
        .RuleFor(i => i.Prod_Quality, f => f.PickRandom(new[] { "A", "B", "C" }))
        .RuleFor(i => i.Quantity, f => f.Random.Number(1, 100))
        .RuleFor(i => i.Stone_Wt, f => f.Random.Decimal(0.1m, 10m))
        .RuleFor(i => i.Tot_Gross_Wt, f => f.Random.Decimal(0.1m, 100m))
        .Generate(20);

      context.Items.AddRange(items);
      context.SaveChanges();
      Console.WriteLine("Thêm dữ liệu cho bảng Items thành công!");
    }

    var validItemIds = context.Items.Select(i => i.Style_Code).ToList();



    if (!context.Stones.Any())
    {


      var uniqueKeys = new HashSet<(string styleCode, int stoneQltyId)>();
      var stones = new List<StoneMst>();
      var faker = new Faker<StoneMst>()
        .RuleFor(s => s.Style_Code, f => f.PickRandom(validItemIds))
        .RuleFor(s => s.StoneQlty_ID, f => f.PickRandom(validStoneQualitieIds))
        .RuleFor(s => s.Stone_Gm, f => f.Random.Decimal(0.1m, 5.0m))
        .RuleFor(s => s.Stone_Pcs, f => f.Random.Number(1, 10))
        .RuleFor(s => s.Stone_Crt, f => f.Random.Decimal(0.1m, 2.5m))
        .RuleFor(s => s.Stone_Rate, f => f.Random.Decimal(100, 5000))
        .RuleFor(s => s.Stone_Amt, (f, s) => s.Stone_Crt * s.Stone_Rate);
        // Giả sử có thêm một thuộc tính mô tả khác nếu cần


      // Tạo 20 bản ghi với composite key duy nhất
      while (stones.Count < 20)
      {
        var stone = faker.Generate();
        var key = (stone.Style_Code, stone.StoneQlty_ID);
        if (uniqueKeys.Add(key))
        {
          stones.Add(stone);
        }
      }

      context.Stones.AddRange(stones);
      context.SaveChanges();
      Console.WriteLine("Seed bảng StoneMst thành công!");
    }


    if (!context.DiamondDetails.Any())
    {


      var uniqueKeys = new HashSet<(string styleCode, int dimQltyId, int dimSubTypeId)>();
      var diamonds = new List<DimMst>();

      // Sử dụng Faker để định nghĩa các rule seed cho DiamondDetails
      var faker = new Faker<DimMst>()
        .RuleFor(d => d.Style_Code, f => f.PickRandom(validItemIds))
        .RuleFor(d => d.DimQlty_ID, f => f.PickRandom(validDiamondQualitieIds))
        .RuleFor(d => d.DimSubType_ID, f => f.PickRandom(validDiamondSubQualitiIds))
        .RuleFor(d => d.Dim_Crt, f => f.Random.Decimal(0.1m, 5.0m))
        .RuleFor(d => d.Dim_Pcs, f => f.Random.Number(1, 10))
        .RuleFor(d => d.Dim_Gm, f => f.Random.Decimal(0.1m, 5.0m))
        .RuleFor(d => d.Dim_Size, f => f.Random.Decimal(0.5m, 3.0m))
        .RuleFor(d => d.Dim_Rate, f => f.Random.Decimal(500, 10000))
        .RuleFor(d => d.Dim_Amt, (f, d) => d.Dim_Crt * d.Dim_Rate);

      // Tạo 20 bản ghi với composite key duy nhất (Style_Code, DimQlty_ID, DimSubType_ID)
      while (diamonds.Count < 20)
      {
        var diamond = faker.Generate();
        var key = (diamond.Style_Code, diamond.DimQlty_ID, diamond.DimSubType_ID);
        if (uniqueKeys.Add(key))
        {
          diamonds.Add(diamond);
        }
      }

      context.DiamondDetails.AddRange(diamonds);
      context.SaveChanges();
      Console.WriteLine("Seed bảng DiamondDetails thành công!");
    }


  }

}
