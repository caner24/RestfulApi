using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Data.Concrete
{
    public class RestfulApiContext : IdentityDbContext<User>
    {
        public RestfulApiContext(DbContextOptions<RestfulApiContext> options) : base(options)
        {
        }

        public RestfulApiContext()
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }



        //<summary> Kalıcı bir veritabanına gereksinim duyulmadığı için proje derlenip kapatılınca veri tabanındakilerin silinmesini istediğim için inmemory kullandım. </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("ProductDemoDb");
            }
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
        //<summary> InMemoryDb kullandığım için proje yeniden başlatılınca veritabanına bir ürün ekliyorum. </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Navigation(x => x.ProductDetail).AutoInclude();
            modelBuilder.Entity<ProductDetail>().HasKey(x => x.ProductId);
            modelBuilder.Entity<ProductDetail>().HasOne(x => x.Product).WithOne(x => x.ProductDetail).HasForeignKey<ProductDetail>(x => x.ProductId);

            // Kitabı yayında olan bir yazar silinememeli. Öncelikle kitap silinmeli, daha sonra yazar silinebilir.
            modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
