using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserOriginEntity> UserOrigin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().HasColumnName("id");
                entity.Property(e => e.Nome).IsRequired().HasColumnName("name").HasMaxLength(200);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasOne(e => e.UserOrigin)
                    .WithMany()
                    .HasForeignKey("UserOriginId")
                    .OnDelete(DeleteBehavior.Cascade);            
            });

            modelBuilder.Entity<UserOriginEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().HasColumnName("id");
                entity.Property(e => e.Origem).IsRequired().HasColumnName("origem").HasMaxLength(1);
                entity.Property(e => e.Descricao).IsRequired().HasColumnName("descricao").HasMaxLength(200);
            });
        }
    }
}

