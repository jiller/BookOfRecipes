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
        public DbSet<Ingredient> Ingredients { get; set; }

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
            modelBuilder.Entity<Recipe>()
                .HasMany<RecipeVariation>()
                .WithOne(rv => rv.Recipe)
                .HasForeignKey(rv => rv.RecipeId);

            modelBuilder.Entity<RecipeVariation>()
                .HasKey(rv => rv.Id);
            modelBuilder.Entity<RecipeVariation>()
                .HasOne<User>(rv => rv.Author)
                .WithMany(u => u.Recipes)
                .HasForeignKey(rv => rv.CreatedBy);

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
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Email = "test@mail.me",
                    Name = "Test User",
                    RoleId = 1
                });

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<Role>()
                .HasMany<RolePermission>()
                .WithOne()
                .HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = 1,
                    Name = "Default Role"
                });

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new
                {
                    rp.RoleId,
                    rp.Permission
                });

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.RecipeVariation)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(i => i.RecipeVariationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}