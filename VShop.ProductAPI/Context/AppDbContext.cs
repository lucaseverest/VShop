using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Product.db");

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categoria
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            //Produto
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ImgURL).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(12, 2);



            //Relacionamento
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                    .WithOne(c => c.Category)
                        .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Carros",
                },
                new Category
                {
                    Id = 2,
                    Name = "Motos",
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
