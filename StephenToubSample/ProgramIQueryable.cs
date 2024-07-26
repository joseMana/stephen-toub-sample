

//using Microsoft.EntityFrameworkCore;

//public class MyDbContext : DbContext
//{
//    public DbSet<MyEntity> MyEntities { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDatabase;Trusted_Connection=True;");
//    }
//}
//public class Program
//{
//    public static void Main()
//    {
//        using (var db = new MyDbContext())
//        {
//            db.Database.EnsureCreated();
//            db.MyEntities.AddRange(
//                new MyEntity { Name = "First" },
//                new MyEntity { Name = "Second" },
//                new MyEntity { Name = "Third" }
//            );
//            db.SaveChanges();
//        }

//        using (var db = new MyDbContext())
//        {
//            var query = db.MyEntities.Where(e => e.Name == "First").Include(e => e.Name);
//            foreach (var entity in query)
//                System.Console.WriteLine(entity.Name);
//        }
//    }
//}

//public class MyEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}