using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SalesReporting.Model
{
    public partial class SalesDBContext : DbContext
    {
        public SalesDBContext()
        {
        }

        public SalesDBContext(DbContextOptions<SalesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SalesReporting> SalesReportings { get; set; }
        public virtual DbSet<TableRecord> TableRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\;Database=Ryde;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=tcp:ryde.database.windows.net,1433;Initial Catalog=ryde;Persist Security Info=False;User ID=rydeadmin;Password=Password#1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SalesReporting>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.ItemType).IsUnicode(false);

                entity.Property(e => e.OrderDate).IsUnicode(false);

                entity.Property(e => e.OrderId).IsUnicode(false);

                entity.Property(e => e.OrderPriority).IsUnicode(false);

                entity.Property(e => e.Region).IsUnicode(false);

                entity.Property(e => e.SalesChannel).IsUnicode(false);

                entity.Property(e => e.ShipDate).IsUnicode(false);
            });

            modelBuilder.Entity<TableRecord>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
