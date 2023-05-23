using Microsoft.EntityFrameworkCore;
using Buyify_Web;

namespace Buyify_Web
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=185.166.188.154;Database=u948053727_buyify;User=u948053727_buyify;Password=Decembre@20144;");
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<UsersCustomers> UsersCustomers { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
