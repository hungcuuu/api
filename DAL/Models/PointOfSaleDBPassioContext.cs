using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class PointOfSaleDBPassioContext : DbContext
    {
        public PointOfSaleDBPassioContext()
        {
        }

        public PointOfSaleDBPassioContext(DbContextOptions<PointOfSaleDBPassioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryExtra> CategoryExtra { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DateReport> DateReport { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderDetailPromotionMapping> OrderDetailPromotionMapping { get; set; }
        public virtual DbSet<OrderPromotionMapping> OrderPromotionMapping { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCollectMapping> ProductCollectMapping { get; set; }
        public virtual DbSet<ProductExtra> ProductExtra { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetail { get; set; }
        public virtual DbSet<RoleName> RoleName { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Table> Table { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("User ID =sa;Password=11223344;Server=localhost;Database=PointOfSaleDBPassio;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasMaxLength(50);

                entity.Property(e => e.StaffName).HasMaxLength(50);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_RoleName");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.AdjustmentNote).HasMaxLength(250);

                entity.Property(e => e.ImageFontAwsomeCss)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('glass')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.CustomerName).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(250);
            });

            modelBuilder.Entity<DateReport>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalCash).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DateReport)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK_DateReport_Account");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ApproveDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovePerson).HasMaxLength(50);

                entity.Property(e => e.Att1).HasMaxLength(250);

                entity.Property(e => e.Att2).HasMaxLength(250);

                entity.Property(e => e.Att3).HasMaxLength(250);

                entity.Property(e => e.Att4).HasMaxLength(250);

                entity.Property(e => e.Att5).HasMaxLength(250);

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckInPerson).HasMaxLength(50);

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutPerson).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(500);

                entity.Property(e => e.DeliveryCustomer).HasMaxLength(50);

                entity.Property(e => e.DeliveryPhone).HasMaxLength(50);

                entity.Property(e => e.FeeDescription).HasMaxLength(250);

                entity.Property(e => e.LastModifiedOrderDetail).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedPayment).HasColumnType("datetime");

                entity.Property(e => e.LastRecordDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.OrderCode).HasMaxLength(50);

                entity.Property(e => e.PasswordWifi).HasMaxLength(50);

                entity.Property(e => e.PaymentCode).HasMaxLength(250);

                entity.Property(e => e.PromotionCode).HasMaxLength(250);

                entity.Property(e => e.ServedPerson).HasMaxLength(50);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.Property(e => e.Vatamount).HasColumnName("VATAmount");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_Order_Source");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Order_Table");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_OrderDetail_1");

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDetailId)
                    .HasColumnName("OrderDetailID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PromotionCode).HasMaxLength(250);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<OrderDetailPromotionMapping>(entity =>
            {
                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PromotionDetailCode)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<OrderPromotionMapping>(entity =>
            {
                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PromotionDetailCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPromotionMapping)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderPromotionMapping_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CardCode).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fcamount)
                    .HasColumnName("FCAmount")
                    .HasColumnType("money");

                entity.Property(e => e.Notes).HasMaxLength(250);

                entity.Property(e => e.PayTime).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Att1).HasMaxLength(50);

                entity.Property(e => e.Att2).HasMaxLength(50);

                entity.Property(e => e.Att3).HasMaxLength(50);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PicUrl).HasColumnName("PicURL");

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.ShortName).HasMaxLength(50);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductCollectMapping>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductCode).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductExtra>(entity =>
            {
                entity.Property(e => e.ExtraProductCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryProductCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeStamp).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ImageCss).HasMaxLength(50);

                entity.Property(e => e.PromotionClassName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PromotionDetail>(entity =>
            {
                entity.Property(e => e.PromotionDetailId).HasColumnName("PromotionDetailID");

                entity.Property(e => e.BuyProductCode).HasMaxLength(250);

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.GiftProductCode).HasMaxLength(50);

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PromotionDetailCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegExCode).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleName>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.Property(e => e.SourceId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.ContactPerson).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");

                entity.Property(e => e.Lat).HasMaxLength(50);

                entity.Property(e => e.Lon).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(100);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.CurrentOrderDate).HasColumnType("datetime");

                entity.Property(e => e.Number).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
