using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace StoreDB.Entities
{
    public partial class StoreContext : DBContext
    {
        public StoreContext(){

        }
        public StoreContext(DBContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public virtual DBSet<Customers> Customers {get; set;}
        public virtual DBSet<Managers> Managers {get; set;}
        public virtual DBSet<Locations> Locations {get; set;}
        public virtual DBSet<BatLocation> BatLocation {get; set;}
        public virtual DBSet<StickLocation> StickLocation{get; set;}
        public virtual DBSet<GamesLocation> GamesLocation {get; set;}
        public virtual DBSet<JerseyLocation> JerseyLocation {get; set;}
        public virtual DBSet<PgStatStatements> PgStatStatements {get; set;}
        public virtual DBSet<Orders> Orders {get; set;}
        public virtual DBSet<Products> Products {get; set;}

        protected override void OnConfiguring(DBContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured){
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") ///may need to readd this
                .Build();

                var connectionString = configuration.GetConnectionString("StoreDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasPostgresExtension("btree_gin")
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

            modelBuilder.Entity<BatLocation>(entity =>
            {
                entity.ToTable("batworld");
                entity.Property(e => e.ID).HasColumnName("productid")
                    .HasConstraintName("batworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<JerseyLocation>(entity =>
            {
                entity.ToTable("jerseyworld");
                entity.Property(e => e.ID).HasColumnName("productid")
                    .HasConstraintName("jerseyworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<GamesLocation>(entity =>
            {
                entity.ToTable("gamesworld");
                entity.Property(e => e.ID).HasColumnName("productid")
                    .HasConstraintName("gamesworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<StickLocation>(entity =>
            {
                entity.ToTable("stickworld");
                entity.Property(e => e.ID).HasColumnName("productid")
                    .HasConstraintName("stickworld_productid_fkey");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.ToTable("managers");
                entity.Property(entity => entity.ID).HasColumnName("id");
                entity.Property(entity => entity.UserName).HasColumnName("name");
                entity.Property(e => e.LocationID).HasColumnName("location")
                    .HasConstraintName("managers_location_fkey");
            });

            modelBuilder.entity<Customers>(entity =>
            {
                entity.ToTable("customers");
                entity.Property(entity => entity.ID).HasColumnName("id");
                entity.Property(entity => entity.UserName).HasColumnName("name");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Email).HasColumnName("email");
            });

            modelBuilder.entity<Locations>(entity =>
            {
                entity.ToTable("locations");
                entity.Property(entity => entity.ID).HasColumnName("id");
                entity.Property(entity => entity.Name).HasColumnName("name");
                entity.Property(entity => entity.Address).HasColumnName("address");
            });

            modelBuilder.entity<Orders>(entity =>
            {
                entity.ToTable("Orders");
                entity.Property(entity => entity.ID).HasColumnName("id");
                entity.Property(entity => entity.CustomerID).HasColumnName("customerid")
                    .HasConstraintName("orders_customerid_fkey");
                entity.Property(entity => entity.LocationID).HasColumnName("locationid")
                    .HasConstraintName("orders_locationid_fkey");
            });

            modelBuilder.entity<Products>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(entity => entity.ID).HasColumnName("id");
                entity.Property(entity => entity.Sport).HasColumnName("sport");
                entity.Property(entity => entity.Athlete).HasColumnName("athlete");
                entity.Property(entity => entity.Item).HasColumnName("item");
                entity.Property(entity => entity.Quantity).HasColumnName("quantity");
                entity.Property(entity => entity.Price).HasColumnName("price");
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
        }
    }
}