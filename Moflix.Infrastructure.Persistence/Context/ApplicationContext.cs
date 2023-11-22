using Microsoft.EntityFrameworkCore;
using Moflix.Core.Domain.Common;
using Moflix.Core.Domain.Entities;

namespace Moflix.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Category { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TABLES

            // Configuración de nombres de tablas
            modelBuilder.Entity<Movies>().ToTable("Movies");
            modelBuilder.Entity<Category>().ToTable("Categories");

            #endregion TABLES

            #region PRIMARY KEYS

            // Configuración de claves primarias
            modelBuilder.Entity<Movies>().HasKey(movie => movie.Id);
            modelBuilder.Entity<Category>().HasKey(category => category.Id);

            #endregion PRIMARY KEYS

            #region RELATIONSHIPS

            // Relación entre Categorías y Películas
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Movies)
                .WithOne(movie => movie.Category)
                .HasForeignKey(movie => movie.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion RELATIONSHIPS

            #region PROPERTY CONFIGURATIONS

            // Configuración de propiedades
            modelBuilder.Entity<Movies>()
                .Property(movie => movie.Title)
                .IsRequired();

            modelBuilder.Entity<Movies>()
                .Property(movie => movie.Synopsis)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(100);

            #endregion PROPERTY CONFIGURATIONS
        }
    }
}