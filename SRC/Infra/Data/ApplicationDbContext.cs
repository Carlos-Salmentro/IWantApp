using Microsoft.EntityFrameworkCore;
using IWantApp.Domain.Products;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
       
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //chamando classe base (IdentityDbContext)
        base.OnModelCreating(builder);
                
        //Product
        builder.Entity<Product>().Property(p => p.Name).HasMaxLength(150).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>().Property(p => p.CategoryId).IsRequired();

        //Category
        builder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

        
        //Ignore
        builder.Ignore<Notification>();
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(30);
    }
}
