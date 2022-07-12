﻿using Microsoft.EntityFrameworkCore;
using IWantApp.Domain.Products;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Product
        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>().Property(p => p.Category).IsRequired();

        //Category
        builder.Entity<Category>().Property(c => c.Name).HasMaxLength(20).IsRequired();
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(30);
    }
}
