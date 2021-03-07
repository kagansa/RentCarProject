using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TUCAPO7\SQLEXPRESS;Database=ReCar;User Id=sa;Password=Paf*13");
        }

        public DbSet<Car> Cars { get; set; }
    }
}