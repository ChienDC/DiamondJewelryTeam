using DiamondJewelry.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiamondJewelry.Data
{
    public class JewelryDbContext(DbContextOptions<JewelryDbContext> options)
        : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<AdminLoginMst> AdminLogins { get; set; }
        public DbSet<BrandMst> Brands { get; set; }
        public DbSet<CatMst> Categories { get; set; }
        public DbSet<CertifyMst> Certifications { get; set; }
        public DbSet<DimMst> DiamondDetails { get; set; }
        public DbSet<DimQltyMst> DiamondQualities { get; set; }
        public DbSet<GoldKrtMst> GoldCarats { get; set; }
        public DbSet<ProdMst> Products { get; set; }
        public DbSet<StoneMst> Stones { get; set; }
        public DbSet<StoneQltyMst> StoneQualities { get; set; }
        public DbSet<UserRegMst> Users { get; set; }
        public DbSet<ItemMst> Items { get; set; }
        public DbSet<DimQltySubMst> DiamondSubQualities { get; set; }
        public DbSet<DimInfoMst> DiamondInfos { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<JewelTypeMst> JewelTypes { get; set; }
        public DbSet<CartList> CartLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary keys
            modelBuilder.Entity<AdminLoginMst>().HasKey(a => a.UserName);
            modelBuilder.Entity<BrandMst>().HasKey(b => b.Brand_ID);
            modelBuilder.Entity<CatMst>().HasKey(c => c.Cat_ID);
            modelBuilder.Entity<CertifyMst>().HasKey(c => c.Certify_ID);
            modelBuilder.Entity<DimQltyMst>().HasKey(d => d.DimQlty_ID);
            modelBuilder.Entity<GoldKrtMst>().HasKey(g => g.GoldType_ID);
            modelBuilder.Entity<ProdMst>().HasKey(p => p.Prod_ID);
            modelBuilder.Entity<StoneQltyMst>().HasKey(s => s.StoneQlty_ID);
            modelBuilder.Entity<UserRegMst>().HasKey(u => u.UserID);
            modelBuilder.Entity<ItemMst>().HasKey(i => i.Style_Code);
            modelBuilder.Entity<DimQltySubMst>().HasKey(d => d.DimSubType_ID);
            modelBuilder.Entity<DimInfoMst>().HasKey(d => d.DimID);
            modelBuilder.Entity<Inquiry>().HasKey(i => i.ID);
            modelBuilder.Entity<JewelTypeMst>().HasKey(j => j.ID);
            modelBuilder.Entity<CartList>().HasKey(c => c.ID);

            // Define composite keys
            modelBuilder.Entity<DimMst>().HasKey(d => new { d.DimQlty_ID, d.DimSubType_ID });
            modelBuilder.Entity<StoneMst>().HasKey(s => new { s.Style_Code, s.StoneQlty_ID });

            // Set up relationships
            modelBuilder.Entity<DimMst>()
                .HasOne<DimQltyMst>()
                .WithMany()
                .HasForeignKey(d => d.DimQlty_ID);

            modelBuilder.Entity<DimMst>()
                .HasOne<DimQltySubMst>()
                .WithMany()
                .HasForeignKey(d => d.DimSubType_ID);

            modelBuilder.Entity<StoneMst>()
                .HasOne<ItemMst>()
                .WithMany()
                .HasForeignKey(s => s.Style_Code);

            modelBuilder.Entity<StoneMst>()
                .HasOne<StoneQltyMst>()
                .WithMany()
                .HasForeignKey(s => s.StoneQlty_ID);

            modelBuilder.Entity<ItemMst>()
              .HasOne(i => i.BrandMst)
              .WithMany()
              .HasForeignKey(i => i.Brand_ID);

            modelBuilder.Entity<ItemMst>()
              .HasOne(i => i.CatMst)
              .WithMany()
              .HasForeignKey(i => i.Cat_ID);

            modelBuilder.Entity<ItemMst>()
              .HasOne(i => i.CertifyMst)
              .WithMany()
              .HasForeignKey(i => i.Certify_ID);

            modelBuilder.Entity<ItemMst>()
              .HasOne(i => i.ProdMst)
              .WithMany()
              .HasForeignKey(i => i.Prod_ID);

            modelBuilder.Entity<ItemMst>()
              .HasOne(i => i.GoldKrtMst)
              .WithMany()
              .HasForeignKey(i => i.GoldType_ID);
        }
    }
}
