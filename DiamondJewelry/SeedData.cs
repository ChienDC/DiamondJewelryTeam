using DiamondJewelry.Data;
using DiamondJewelry.DatabaseSeeder;
using Microsoft.EntityFrameworkCore;

namespace DiamondJewelry;

public class Program1
{
  static void Main()
  {
    var services = new ServiceCollection();
    services.AddDbContext<JewelryDbContext>(options =>
      options.UseSqlServer("Server=localhost;Database=JewelryDB;User Id=sa;Password=123;"));

    using (var serviceProvider = services.BuildServiceProvider())
    {
      using (var context = serviceProvider.GetRequiredService<JewelryDbContext>())
      {
        Console.WriteLine("Seeding database...");
        DiamondDetailSeeder.Seed(context);
        Console.WriteLine("Database seeding complete.");
      }
    }
  }
}
