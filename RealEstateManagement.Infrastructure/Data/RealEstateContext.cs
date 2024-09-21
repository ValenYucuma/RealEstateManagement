using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Data
{

    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options) // Llama al constructor base y pasa las opciones
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PropertyImage>()
                .HasKey(p => p.IdPropertyImage);

            modelBuilder.Entity<PropertyTrace>()
                .HasKey(p => p.IdPropertyTrace);

            modelBuilder.Entity<Property>()
                .HasKey(p => p.IdProperty);

            modelBuilder.Entity<Owner>()
                .HasKey(o => o.IdOwner);

            modelBuilder.Entity<Property>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Properties)
                .HasForeignKey(p => p.IdOwner)
                .OnDelete(DeleteBehavior.Cascade); // O NO ACTION


            modelBuilder.Entity<PropertyImage>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(pi => pi.IdProperty)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyTrace>()
                .HasOne(pt => pt.Property)
                .WithMany(p => p.PropertyPrices)
                .HasForeignKey(pt => pt.IdProperty)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyTrace>()
                .Property(pt => pt.Value)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<PropertyTrace>()
                .Property(pt => pt.Tax)
                .HasColumnType("decimal(18, 2)");
        }
    }

}



