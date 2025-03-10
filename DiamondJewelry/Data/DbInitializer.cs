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
                .RuleFor(b => b.Brand_Type, f => f.Company.CompanyName()) // No need to add Brand_ID as it is Identity
                .Generate(20);
            context.Brands.AddRange(brands);
        }

        if (!context.Categories.Any())
        {
            var categories = new Faker<CatMst>()
                .RuleFor(c => c.Cat_Name, f => f.Commerce.Categories(1)[0]) // No need to add Cat_ID as it is Identity
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

        if (!context.DiamondQualities.Any())
        {
            var diamondQualities = new Faker<DimQltyMst>()
                .RuleFor(q => q.DimQlty_ID, f => f.UniqueIndex + 1) // Generate unique ID
                .RuleFor(q => q.DimQlty, f => f.PickRandom("AD", "FD", "VVS1", "VVS2", "VS1"))
                .Generate(20);

            context.DiamondQualities.AddRange(diamondQualities);
            context.SaveChanges();
            Console.WriteLine("Successfully added data to DiamondQualities table!");
        }

        if (!context.DiamondSubQualities.Any())
        {
            var diamondQualitiesSub = new Faker<DimQltySubMst>()
                .RuleFor(q => q.DimSubType_ID, f => f.UniqueIndex + 1) // Generate unique ID
                .RuleFor(q => q.DimQlty, f => f.PickRandom("AD", "FD", "VVS1", "VVS2", "VS1", "VS2"))
                .Generate(20);

            context.DiamondSubQualities.AddRange(diamondQualitiesSub);
            context.SaveChanges();
            Console.WriteLine("Successfully added data to DiamondSubQualities table!");
        }

        if (!context.Certifications.Any())
        {
            var certifications = new Faker<CertifyMst>()
                .RuleFor(c => c.Certify_Type, f => f.Random.Number(900, 999).ToString())
                .Generate(20);

            context.Certifications.AddRange(certifications);
            context.SaveChanges();
            Console.WriteLine("Successfully added data to Certifications table!");
        }

        if (!context.StoneQualities.Any())
        {
            var stoneQualities = new Faker<StoneQltyMst>()
                .RuleFor(s => s.StoneQlty, f => f.Lorem.Word())
                .Generate(20);

            context.StoneQualities.AddRange(stoneQualities);
            context.SaveChanges();
            Console.WriteLine("Successfully added data to StoneQualities table!");
        }

        if (!context.Products.Any())
        {
            var products = new Faker<ProdMst>()
                .RuleFor(p => p.Prod_Type, f => f.PickRandom("Ring", "Necklace", "Earrings", "Bracelet"))
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

        if (!context.Items.Any())
        {
            var items = new Faker<ItemMst>()
                .RuleFor(i => i.Style_Code, f => $"D{f.UniqueIndex + 100}")
                .RuleFor(i => i.MRP, f => f.Random.Decimal(1000, 50000))
                .RuleFor(i => i.Quantity, f => f.Random.Number(1, 100))
                .Generate(20);

            context.Items.AddRange(items);
            context.SaveChanges();
            Console.WriteLine("Successfully added data to Items table!");
        }

        if (!context.Stones.Any())
        {
            var stones = new Faker<StoneMst>()
                .RuleFor(s => s.Stone_Gm, f => f.Random.Decimal(0.1m, 5.0m))
                .Generate(20);

            context.Stones.AddRange(stones);
            context.SaveChanges();
            Console.WriteLine("Successfully seeded StoneMst table!");
        }

        if (!context.DiamondDetails.Any())
        {
            var diamonds = new Faker<DimMst>()
                .RuleFor(d => d.Dim_Crt, f => f.Random.Decimal(0.1m, 5.0m))
                .Generate(20);

            context.DiamondDetails.AddRange(diamonds);
            context.SaveChanges();
            Console.WriteLine("Successfully seeded DiamondDetails table!");
        }
    }
}
