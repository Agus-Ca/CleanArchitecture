using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework
{
    public partial class ComidasDBContext : DbContext
    {
        public ComidasDBContext()
        {
        }

        public ComidasDBContext(DbContextOptions<ComidasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comida> Comida { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AGUSCA-PC\\SQLEXPRESS; Database=ComidasDB; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comida>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinVigencia).HasColumnType("datetime");

                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Ingredientes)
                    .WithMany(p => p.Comida)
                    .UsingEntity<Dictionary<string, object>>(
                        "ComidaIngrediente",
                        l => l.HasOne<Ingrediente>().WithMany().HasForeignKey("IngredienteId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_IngredienteId"),
                        r => r.HasOne<Comida>().WithMany().HasForeignKey("ComidaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ComidaId"),
                        j =>
                        {
                            j.HasKey("ComidaId", "IngredienteId").HasName("PK__ComidaIn__4F0B0BF3B8E5C361");

                            j.ToTable("ComidaIngrediente");
                        });
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.ToTable("Ingrediente");

                entity.Property(e => e.FechaFinVigencia).HasColumnType("datetime");

                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
