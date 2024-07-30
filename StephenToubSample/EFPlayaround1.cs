

//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//public class MyDbContext : DbContext
//{
//    public DbSet<User> Users { get; set; }
//    public DbSet<UserInfo> UserInfos { get; set; }
//    public DbSet<UserDepartment> UserDepartments { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFPlayaround;Trusted_Connection=True;");
//    }
//}
//public class Program
//{
//    public static void Main()
//    {
//        using (var db = new MyDbContext())
//        {
//            db.Database.EnsureCreated();

//            var user = new User();
//            user.UserInfos = new List<UserInfo>
//            {
//                new UserInfo
//                {
//                    Name = "2"
//                }
//            };
//            user.UserDepartments = new List<UserDepartment>
//            {
//                new UserDepartment
//                {
//                    Name = "e"
//                }
//            };
//            db.Users.Add(user);
//            db.SaveChanges();
//        }

//        using (var db = new MyDbContext())
//        {
//            var user = db.Users.Include(u => u.UserInfos).Include(u => u.UserDepartments).FirstOrDefault();
//            Console.WriteLine(user.UserInfos.First().Name);
//            Console.WriteLine(user.UserDepartments.First().Name);
//        }
//    }
//}
//public class User
//{
//    [Key]
//    public int Id { get; set; }
//    [ForeignKey("Id")]
//    public int UserInfoId { get; set; }
//    [ForeignKey("Id")]
//    public int UserDepartmentId { get; set; }
//    public virtual ICollection<UserInfo> UserInfos { get; set; }
//    public virtual ICollection<UserDepartment> UserDepartments { get; set; }
//}
//public class UserInfo
//{
//    [Key]
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
//public class UserDepartment
//{
//    [Key]
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
