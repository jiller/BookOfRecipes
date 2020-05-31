using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.Data
{
    public class BookOfRecipesContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeVariation> RecipeVariations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public BookOfRecipesContext(DbContextOptions<BookOfRecipesContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Recipe>()
                .Property(r => r.Name)
                .HasMaxLength(200);

            modelBuilder.Entity<RecipeVariation>()
                .HasBaseType<Recipe>();
            modelBuilder.Entity<RecipeVariation>()
                .HasOne<User>()
                .WithMany(u => u.Recipes)
                .HasForeignKey(rv => rv.CreatedBy);
            modelBuilder.Entity<RecipeVariation>()
                .HasOne<User>()
                .WithMany(u => u.Recipes)
                .HasForeignKey(rv => rv.UpdatedBy);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(200);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<Role>()
                .HasMany<RolePermission>()
                .WithOne()
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new
                {
                    rp.RoleId,
                    rp.Permission
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}