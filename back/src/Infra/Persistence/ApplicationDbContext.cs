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
        public DbSet<TypeEntity> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("usuarios");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id_usu")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                      .HasColumnName("nome_usu")
                      .IsRequired();

                entity.Property(e => e.Registration)
                      .HasColumnName("matr_usu");

                entity.Property(e => e.DateOfBirth)
                      .HasColumnName("data_nasc");

                entity.Property(e => e.EmailAddress)
                      .HasColumnName("email");

                entity.Property(e => e.TypeId)
                      .HasColumnName("id_tipousuario")
                      .IsRequired();
            });

            modelBuilder.Entity<TypeEntity>(entity =>
            {
                entity.ToTable("tipos_usuario");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id_tipousuario")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                      .HasColumnName("desc")
                      .IsRequired();

                entity.Property(e => e.Origin)
                      .HasColumnName("origem")
                      .IsRequired();

                entity.HasMany(e => e.Users)
                      .WithOne(u => u.Type)
                      .HasForeignKey(u => u.TypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}