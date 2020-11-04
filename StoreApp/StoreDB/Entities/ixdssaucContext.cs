using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreUI.Entities
{
    public partial class ixdssaucContext : DbContext
    {
        public ixdssaucContext()
        {
        }

        public ixdssaucContext(DbContextOptions<ixdssaucContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<LineItems> LineItems { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=lallah.db.elephantsql.com;Port=5432;Database=ixdssauc;Username=ixdssauc;Password=TaJeWT22Nmhi-cD0Irk2sOermZ4AvenE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.ToTable("Cart Items");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cart).HasColumnName("cart");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CartNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Cart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Carts)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany()
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product");
            });

            modelBuilder.Entity<LineItems>(entity =>
            {
                entity.ToTable("Line Items");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Order)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Id)
                    .HasName("ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Manager).HasColumnName("manager");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Manager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manager");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order date")
                    .HasColumnType("date");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Orders)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Products_ID_ID1_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Athlete)
                    .IsRequired()
                    .HasColumnName("athlete")
                    .HasColumnType("character varying");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnName("item")
                    .HasColumnType("character varying");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Sport)
                    .IsRequired()
                    .HasColumnName("sport")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
