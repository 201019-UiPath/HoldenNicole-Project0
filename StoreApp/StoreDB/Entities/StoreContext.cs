using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreDB.Entities
{
    public partial class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Customers> Customer { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Locations> Location { get; set; }
        public virtual DbSet<BatLocation> BatLocations { get; set; }
        public virtual DbSet<StickLocation> StickLocations { get; set; }
        public virtual DbSet<GamesLocation> GamesLocations { get; set; }
        public virtual DbSet<JerseyLocation> JerseyLocations { get; set; }
        public virtual DbSet<Orders> Order { get; set; }
        public virtual DbSet<Products> Product { get; set; }
        public object Sport { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") ///may need to readd this
                .Build();

                var connectionString = configuration.GetConnectionString("StoreDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatLocation>(entity =>
            {
                entity.ToTable("batworld");
                entity.Property(e => e.ID).HasColumnName("productid");
                 //   .HasConstraintName("batworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<JerseyLocation>(entity =>
            {
                entity.ToTable("jerseyworld");
                entity.Property(e => e.ID).HasColumnName("productid");
                 //   .HasConstraintName("jerseyworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<GamesLocation>(entity =>
            {
                entity.ToTable("gamesworld");
                entity.Property(e => e.ID).HasColumnName("productid");
                //    .HasConstraintName("gamesworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<StickLocation>(entity =>
            {
                entity.ToTable("stickworld");
                entity.Property(e => e.ID).HasColumnName("productid");
                //    .HasConstraintName("stickworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.ToTable("managers");
                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LocationID).HasColumnName("location");
                  //  .HasConstraintName("managers_location_fkey");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");
                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.UserName).HasColumnName("name");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Email).HasColumnName("email");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");
                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Address).HasColumnName("address");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders");
                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.date).HasColumnName("date");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.CustomerID).HasColumnName("customerid");
                   // .HasConstraintName("orders_customerid_fkey");
                entity.Property(e => e.LocationID).HasColumnName("locationid");
                   // .HasConstraintName("orders_locationid_fkey");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(e => e.ID).HasColumnName("id");
                entity.Property(e => e.Sport).HasColumnName("sport");
                entity.Property(e => e.Athlete).HasColumnName("athlete");
                entity.Property(e => e.Item).HasColumnName("item");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Price).HasColumnName("price");
            });
        }
    }
}