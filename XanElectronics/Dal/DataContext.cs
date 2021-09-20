using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XanElectronics.Models;

namespace XanElectronics.Dal
{
    public class DataContext :IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //bio
            modelBuilder.Entity<Bio>().HasData(
                new Bio
                {
                    Id = 1, HeaderLogoUrl = "logo-dark.jpg",FooterLogoUrl = "logo-dark.jpg",Phone = "+994555535373",
                    Email = "orkhanmm@code.edu.az",Address = "Baku city,Sabail district",Facebook="www.facebook.com",Twitter="www.twitter.com",
                    Youtube="www.youtube.com",Instagram="www.instagram.com"
                }
            );
            
            //category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1, Name = "phone",ProductCount = 4,IsPopular = true,
                    IsDeleted = false,ImageUrl = "1.jpg"
                },
                new Category
                {
                    Id = 2, Name = "laptop",ProductCount = 4,IsPopular = true,
                    IsDeleted = false,ImageUrl = "1.jpg"
                }
            );
            
            //brand
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1, Name = "apple",ImageUrl = "1.jpg"
                },
                new Brand
                {
                    Id = 2, Name = "samsung",ImageUrl = "1.jpg"
                },
                new Brand
                {
                    Id = 3, Name = "xiaomi",ImageUrl = "1.jpg"
                },
                new Brand
                {
                    Id = 4, Name = "nokia",ImageUrl = "1.jpg"
                }
            );
            
            //product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1, Name = "iphone1",Price = 3000,
                    ResultPrice = 2700,DisCountRate = 10,Count = 50,Star = 5,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "11",Size = "X",CategoryId = 1,BrandId = 1
                },
                
                new Product
                {
                    Id = 2, Name = "samsung1",Price = 2000,
                    ResultPrice = 1800,DisCountRate = 10,Count = 50,Star = 4,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "12",Size = "X",CategoryId = 1,BrandId = 2
                },
                new Product
                {
                    Id = 3, Name = "xiaomi1",Price = 1000,
                    ResultPrice = 1000,DisCountRate = 10,Count = 50,Star = 4,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "13",Size = "X",CategoryId = 1,BrandId = 3
                },
                new Product
                {
                    Id = 4, Name = "nokia1",Price = 200,
                    ResultPrice = 200,DisCountRate = 0,Count = 50,Star = 2,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "14",Size = "X",CategoryId = 1,BrandId = 4
                },
                new Product
                {
                    Id = 5, Name = "iphone2",Price = 3000,
                    ResultPrice = 2700,DisCountRate = 10,Count = 50,Star = 5,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "15",Size = "X",CategoryId = 2,BrandId = 1
                },
                
                new Product
                {
                    Id = 6, Name = "samsung2",Price = 2000,
                    ResultPrice = 1800,DisCountRate = 10,Count = 50,Star = 4,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "16",Size = "X",CategoryId = 2,BrandId = 2
                },
                new Product
                {
                    Id = 7, Name = "xiaomi2",Price = 1000,
                    ResultPrice = 1000,DisCountRate = 10,Count = 50,Star = 4,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "17",Size = "X",CategoryId = 2,BrandId = 3
                },
                new Product
                {
                    Id = 8, Name = "nokia2",Price = 200,
                    ResultPrice = 200,DisCountRate = 0,Count = 50,Star = 2,
                    IsDeleted = false,IsNew = true,IsFeatured = true,IsOriginal = true,
                    LongDescription = "...",ShortDescription = "..",Color = "ag",
                    Code = "18",Size = "X",CategoryId = 2,BrandId = 4
                }
            );
            
            //productimages
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    Id = 1, ImageUrl = "1.jpg",ProductId = 1
                },
                new ProductImage
                {
                    Id = 2, ImageUrl = "1.jpg",ProductId = 2
                },
                new ProductImage
                {
                    Id = 3, ImageUrl = "1.jpg",ProductId = 3
                },
                new ProductImage
                {
                    Id = 4, ImageUrl = "1.jpg",ProductId = 4
                },
                new ProductImage
                {
                    Id = 5, ImageUrl = "1.jpg",ProductId = 5
                },
                new ProductImage
                {
                    Id = 6, ImageUrl = "1.jpg",ProductId = 6
                },
                new ProductImage
                {
                    Id = 7, ImageUrl = "1.jpg",ProductId = 7
                },
                new ProductImage
                {
                    Id = 8, ImageUrl = "1.jpg",ProductId = 8
                }
            );
        }
    }
}
