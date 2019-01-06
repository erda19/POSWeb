using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesApp.Data.Models
{
    public partial class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MsProductcategory> MsProductcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseMySql("Server=localhost;User=root;Password=erda19;port=3307;Database=salesdb");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsProductcategory>(entity =>
            {
                entity.ToTable("ms_productcategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("modifiedBy")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
