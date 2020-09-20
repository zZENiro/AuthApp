using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AuthApp.DataContext
{
    public partial class DesignersShopDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DesignersShopDbContext()
        {
        }

        public DesignersShopDbContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public DesignersShopDbContext(DbContextOptions<DesignersShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clothe> Clothe { get; set; }
        public virtual DbSet<ClotheItem> ClotheItem { get; set; }
        public virtual DbSet<ClotheOfProduct> ClotheOfProduct { get; set; }
        public virtual DbSet<Furniture> Furniture { get; set; }
        public virtual DbSet<FurnitureItem> FurnitureItem { get; set; }
        public virtual DbSet<FurnituresOfProduct> FurnituresOfProduct { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=designersShop_db; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothe>(entity =>
            {
                entity.HasKey(e => e.ClothCode)
                    .HasName("PK_clothes_tbl");

                entity.Property(e => e.ClothCode)
                    .HasColumnName("cloth_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Composition)
                    .HasColumnName("composition")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pattern)
                    .HasColumnName("pattern")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<ClotheItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_ClothesStore_tbl");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ClothCode)
                    .IsRequired()
                    .HasColumnName("cloth_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.ClothCodeNavigation)
                    .WithMany(p => p.ClotheItem)
                    .HasForeignKey(d => d.ClothCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClothesStore_tbl_clothes_tbl");
            });

            modelBuilder.Entity<ClotheOfProduct>(entity =>
            {
                entity.HasKey(e => new { e.ClothCode, e.ProductCode })
                    .HasName("PK_ClothesOfProducts_tbl");

                entity.Property(e => e.ClothCode)
                    .HasColumnName("cloth_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClothCodeNavigation)
                    .WithMany(p => p.ClotheOfProduct)
                    .HasForeignKey(d => d.ClothCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClothesOfProducts_tbl_clothes_tbl");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.ClotheOfProduct)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClothesOfProducts_tbl_product_tbl");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasKey(e => e.FurnitureCode)
                    .HasName("PK_furniture_tbl");

                entity.Property(e => e.FurnitureCode)
                    .HasColumnName("furniture_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<FurnitureItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_furnitureStore_tbl");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.FurnitureCode)
                    .IsRequired()
                    .HasColumnName("furniture_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FurnitureCodeNavigation)
                    .WithMany(p => p.FurnitureItem)
                    .HasForeignKey(d => d.FurnitureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_furnitureStore_tbl_furniture_tbl");
            });

            modelBuilder.Entity<FurnituresOfProduct>(entity =>
            {
                entity.HasKey(e => new { e.FurnitureCode, e.ProductCode })
                    .HasName("PK_furnituresOfProducts_tbl");

                entity.Property(e => e.FurnitureCode)
                    .HasColumnName("furniture_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Placement)
                    .IsRequired()
                    .HasColumnName("placement")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.FurnitureCodeNavigation)
                    .WithMany(p => p.FurnituresOfProduct)
                    .HasForeignKey(d => d.FurnitureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_furnituresOfProducts_tbl_furniture_tbl");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.FurnituresOfProduct)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_furnituresOfProducts_tbl_product_tbl");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("customer_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StageId).HasColumnName("stage_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_tbl_users_tbl");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.OrderManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_orders_tbl_users_tbl1");
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductCode })
                    .HasName("PK_orderedProducts_tbl");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedProduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderedProducts_tbl_orders_tbl");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.OrderedProduct)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderedProducts_tbl_product_tbl");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode)
                    .HasName("PK_product_tbl");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(255);

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK_users_tbl_1");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
