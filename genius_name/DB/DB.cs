using Microsoft.EntityFrameworkCore;
using genius_name.Model;

namespace genius_name.DB
{
    public class DB: DbContext
    {
        public DB() 
        {
            Database.EnsureCreated();
        }

        public DbSet<Passport> Passports { get; set; }
        public DbSet<Snils> Snilses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
