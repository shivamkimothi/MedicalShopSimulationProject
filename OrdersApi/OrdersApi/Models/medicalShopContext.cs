using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrdersApi.Models
{
    public partial class medicalShopContext : DbContext
    {

        public medicalShopContext(DbContextOptions<medicalShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.ToTable("medicine");

                entity.Property(e => e.Mid)
                    .HasColumnName("mid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnName("mname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("orders");

                entity.Property(e => e.Oid)
                    .HasColumnName("oid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dateoforder)
                    .HasColumnName("dateoforder")
                    .HasColumnType("date");

                entity.Property(e => e.Mid).HasColumnName("mid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");

                entity.HasOne(d => d.M)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_medicine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
