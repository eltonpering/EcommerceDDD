using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<IdentityUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }


        public DbSet<Produto> Produto { get; set;  }
        public DbSet<CompraUsuario> CompraUsuario { get; set; }
        public  DbSet<IdentityUser> IdentityUser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }


        private string GetStringConectionConfig()
        {
            string strCon = "User ID=postgres;Password=master;Server=localhost;Port=5432;Database=DDD_ECOMMERCE;Integrated Security=true; Pooling=true;";
            return strCon;
        }
    }
}
