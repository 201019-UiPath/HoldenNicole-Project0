using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreUI.Entities
{
    public partial class hyfhtbziContext : DbContext
    {
        public hyfhtbziContext()
        {
        }

        public hyfhtbziContext(DbContextOptions<hyfhtbziContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batworld> Batworld { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Gamesworld> Gamesworld { get; set; }
        public virtual DbSet<Jerseyworld> Jerseyworld { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Products1> Products1 { get; set; }
        public virtual DbSet<Stickworld> Stickworld { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=lallah.db.elephantsql.com;Port=5432;Database=hyfhtbzi;Username=hyfhtbzi;Password=n2KsBr7QAHgLPt1zQdxw-J1pXfmtmUFI");
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

            modelBuilder.Entity<Batworld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("batworld");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("batworld_productid_fkey");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Gamesworld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gamesworld");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("gamesworld_productid_fkey");
            });

            modelBuilder.Entity<Jerseyworld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("jerseyworld");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("jerseyworld_productid_fkey");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.ToTable("managers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(80);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("managers_location_fkey");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("orders_customerid_fkey");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("orders_locationid_fkey");
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
                entity.ToTable("products", "SportsAuthenticated");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Athlete)
                    .IsRequired()
                    .HasColumnName("athlete")
                    .HasMaxLength(80);

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnName("item")
                    .HasMaxLength(100);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sport)
                    .IsRequired()
                    .HasColumnName("sport")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Products1>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Athlete)
                    .IsRequired()
                    .HasColumnName("athlete")
                    .HasMaxLength(80);

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnName("item")
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sport)
                    .IsRequired()
                    .HasColumnName("sport")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Stickworld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stickworld");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("stickworld_productid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
