﻿using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{
    /*
    dotnet ef migrations add modDb120 --context    DbContextMainData
    dotnet ef database update --context DbContextMainData
    dotnet ef migrations remove --context DbContextMainData
    */

    public class DbContextMainData : DbContext
    {
        public DbContextMainData()
        {
        }
        public DbContextMainData(DbContextOptions<DbContextMainData> options)
    : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H7EA1N4;Initial Catalog=blazorPos;Integrated Security=True;TrustServerCertificate=True");
            }
        }
        public virtual DbSet<Company> Pos_Companies { get; set; }
        public virtual DbSet<Product> Pos_Products { get; set; }
        public DbSet<ProductTag> Pos_ProductTags { get; set; }
        public virtual DbSet<Order> Pos_Orders { get; set; }
        public virtual DbSet<OrderLine> Pos_OrderLines { get; set; }
        public virtual DbSet<Customer> Pos_Customers { get; set; }
        public virtual DbSet<Shift> Pos_Shifts { get; set; }
        // Add a new table for storing the last invoice number used for each company
        public DbSet<CompanyInvoiceNumber> CompanyInvoiceNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            // ...

            // Seed data for the company invoice numbers
            modelBuilder.Entity<CompanyInvoiceNumber>()
                .HasData(
                    new CompanyInvoiceNumber { Id = 1, CompanyId = 1, LastInvoiceNumber = 0 },
                    new CompanyInvoiceNumber { Id = 2, CompanyId = 2, LastInvoiceNumber = 0 }
                );

            // This allows for a many-to - many relationship between Product and ProductTag
            modelBuilder.Entity<ProductTag>()
    .HasKey(pt => pt.Id);

            modelBuilder.Entity<ProductTag>()
                .HasMany(pt => pt.Products)
                .WithMany(p => p.ProductTags)
                .UsingEntity(j => j.ToTable("Pos_ProductProductTag"));




            /*            modelBuilder.Entity<Product>()
                        .HasMany(e => e.RelatedProducts)
                        .WithOne(e => e.ParentProduct)
                        .OnDelete(DeleteBehavior.SetNull);*/
        }

        /* 
         * dotnet ef migrations add modDb099 --context DbContextMainData
  dotnet ef database update --context DbContextMainData
         */
    }

    // Company model
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class CompanyInvoiceNumber
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LastInvoiceNumber { get; set; }
    }
}