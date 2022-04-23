using Microsoft.EntityFrameworkCore;
using _01_Learning_Core_Structure.Infra.Database.Model;

namespace _01_Learning_Core_Structure.Infra.Database.EntityFramework {
    public class EntityContext : DbContext {
        public DbSet<User> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}