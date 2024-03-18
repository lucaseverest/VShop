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

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categoria
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Descricao).HasMaxLength(255).IsRequired();

            //Produto
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Descricao).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(p => p.ImgUrl).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(p => p.Preco).HasPrecision(14, 2);

            //Relacionamento
            modelBuilder.Entity<Produto>()
                .HasOne<Category>(c => c.Categoria)
                    .WithMany(p => p.Produtos)
                        .HasForeignKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
        */
    }
}
