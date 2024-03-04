using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LongShop3.Models
{
    public partial class SHOPLONG5Context : DbContext
    {
        public SHOPLONG5Context()
        {
        }

        public SHOPLONG5Context(DbContextOptions<SHOPLONG5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<ContentAboutu> ContentAboutus { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupAccount> GroupAccounts { get; set; } = null!;
        public virtual DbSet<GroupFeature> GroupFeatures { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<SizeColorStock> SizeColorStocks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetValue<string>("ConnectionStrings:DBContext"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AddressName)
                    .HasMaxLength(250)
                    .HasColumnName("address_name");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__usernam__70DDC3D8");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brand_name");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CommonId).HasColumnName("common_id");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("create_at");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Common)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CommonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__common_id__71D1E811");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__username__72C60C4A");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CateUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cate_url");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("create_at");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("color_name");
            });

            modelBuilder.Entity<ContentAboutu>(entity =>
            {
                entity.HasKey(e => e.Contentid)
                    .HasName("PK__Content___0BDD8B3168979BD8");

                entity.ToTable("Content_aboutus");

                entity.Property(e => e.Contentid).HasColumnName("contentid");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("create_by");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ContentAboutus)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK__Content_a__creat__73BA3083");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.Discountid).HasColumnName("discountid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("discount_percent");

                entity.Property(e => e.EndAt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("end_at");

                entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");

                entity.Property(e => e.StartAt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("start_at");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductDetailId)
                    .HasConstraintName("FK__Discount__produc__74AE54BC");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("groupName");
            });

            modelBuilder.Entity<GroupAccount>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Username })
                    .HasName("PK__GroupAcc__FA4A29F7E6D5E82C");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Createat)
                    .HasMaxLength(10)
                    .HasColumnName("createat");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAccounts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupAcco__group__75A278F5");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.GroupAccounts)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupAcco__usern__76969D2E");
            });

            modelBuilder.Entity<GroupFeature>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.FeatureId })
                    .HasName("PK__GroupFea__B2E7F91DDA377E04");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.Createat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("createat");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.GroupFeatures)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupFeat__featu__778AC167");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupFeatures)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupFeat__group__787EE5A0");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__color_id__797309D9");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__product___7A672E12");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_date");

                entity.Property(e => e.StatusOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_order");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_price");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order__username__7B5B524B");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.Property(e => e.OrderdetailId).HasColumnName("orderdetail_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CommonId).HasColumnName("common_id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.TotalUnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_unit_price");

                entity.HasOne(d => d.Common)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CommonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__commo__7C4F7684");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__order__7D439ABD");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("Product_Details");

                entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("create_at");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSale)
                    .HasColumnName("isSale")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product_D__brand__7E37BEF6");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_D__categ__7F2BE32F");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("comment");

                entity.Property(e => e.CommonId).HasColumnName("common_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("review_date");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Common)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CommonId)
                    .HasConstraintName("FK__Reviews__common___00200768");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Reviews__usernam__01142BA1");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("size_name");
            });

            modelBuilder.Entity<SizeColorStock>(entity =>
            {
                entity.HasKey(e => e.CommonId)
                    .HasName("PK__Size_Col__49F1F09BD54B655C");

                entity.ToTable("Size_Color_Stock");

                entity.Property(e => e.CommonId).HasColumnName("common_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ProductDetailId).HasColumnName("product_detail_id");

                entity.Property(e => e.QuantityStock).HasColumnName("quantity_stock");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.SizeColorStocks)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__Size_Colo__color__02084FDA");

                entity.HasOne(d => d.ProductDetail)
                    .WithMany(p => p.SizeColorStocks)
                    .HasForeignKey(d => d.ProductDetailId)
                    .HasConstraintName("FK__Size_Colo__produ__02FC7413");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.SizeColorStocks)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Size_Colo__size___03F0984C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__F3DBC573C25AC361");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("avatar_url");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("create_at");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .HasColumnName("displayName");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
