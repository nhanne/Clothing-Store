﻿// <auto-generated />
using System;
using Clothings_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clothings_Store.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clothings_Store.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id")
                        .HasName("PK__Colors__3214EC074B6E2D47");

                    b.ToTable("Colors", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Member")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK__Customer__3214EC0739C90AAD");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Job_title", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliTime")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("OrdTime")
                        .HasColumnType("date");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int?>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__tmp_ms_x__3214EC076065A524");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StaffId");

                    b.HasIndex("Status");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("unitPrice");

                    b.HasKey("OrderId", "StockId")
                        .HasName("PK__tmp_ms_x__F1586153AC1F7631");

                    b.HasIndex("StockId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.OrderStatus", b =>
                {
                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Status")
                        .HasName("PK__tmp_ms_x__3A15923EEC714ED5");

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ghichu")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Payment__3214EC07CB929B86");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<double?>("CostPrice")
                        .HasColumnType("float")
                        .HasColumnName("costPrice");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sale")
                        .HasColumnType("int");

                    b.Property<int?>("Sold")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StockInDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("stockInDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("unitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("promotion_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("discount_percentage");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<string>("PromotionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("promotion_name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("PromotionId")
                        .HasName("PK__Promotio__2CB9556BBEE408D1");

                    b.ToTable("Promotions", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ghichu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id")
                        .HasName("PK__Sizes__3214EC07D711A6F5");

                    b.ToTable("Sizes", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cmt")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("CMT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("JobTitle")
                        .HasColumnType("int")
                        .HasColumnName("Job_title");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id")
                        .HasName("PK__Staff__3214EC07D20549E0");

                    b.HasIndex("JobTitle");

                    b.ToTable("Staff", null, t =>
                        {
                            t.HasTrigger("ASP_AbortRoleAdmin");
                        });
                });

            modelBuilder.Entity("Clothings_Store.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<int?>("Stock1")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.Property<DateTime?>("StockInDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("stockInDate")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__Stock__3214EC078808D165");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("Stock", (string)null);
                });

            modelBuilder.Entity("Clothings_Store.Models.Order", b =>
                {
                    b.HasOne("Clothings_Store.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Order__CustomerI__30C33EC3");

                    b.HasOne("Clothings_Store.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__Order__PaymentId__32AB8735");

                    b.HasOne("Clothings_Store.Models.Staff", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK__Order__StaffId__31B762FC");

                    b.HasOne("Clothings_Store.Models.OrderStatus", "StatusNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Status")
                        .HasConstraintName("FK__Order__Status__2FCF1A8A");

                    b.Navigation("Customer");

                    b.Navigation("Payment");

                    b.Navigation("Staff");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("Clothings_Store.Models.OrderDetail", b =>
                {
                    b.HasOne("Clothings_Store.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Order__2EDAF651");

                    b.HasOne("Clothings_Store.Models.Stock", "Stock")
                        .WithMany("OrderDetails")
                        .HasForeignKey("StockId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Stock__2180FB33");

                    b.Navigation("Order");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Clothings_Store.Models.Product", b =>
                {
                    b.HasOne("Clothings_Store.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Product__Categor__267ABA7A");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Clothings_Store.Models.Staff", b =>
                {
                    b.HasOne("Clothings_Store.Models.JobTitle", "JobTitleNavigation")
                        .WithMany("Staff")
                        .HasForeignKey("JobTitle")
                        .HasConstraintName("FK_STAFF");

                    b.Navigation("JobTitleNavigation");
                });

            modelBuilder.Entity("Clothings_Store.Models.Stock", b =>
                {
                    b.HasOne("Clothings_Store.Models.Color", "Color")
                        .WithMany("Stocks")
                        .HasForeignKey("ColorId")
                        .HasConstraintName("FK__Stock__ColorId__19DFD96B");

                    b.HasOne("Clothings_Store.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Stock__ProductId__18EBB532");

                    b.HasOne("Clothings_Store.Models.Size", "Size")
                        .WithMany("Stocks")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK__Stock__SizeId__1AD3FDA4");

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Clothings_Store.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Clothings_Store.Models.Color", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Clothings_Store.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Clothings_Store.Models.JobTitle", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Clothings_Store.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Clothings_Store.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Clothings_Store.Models.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Clothings_Store.Models.Product", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Clothings_Store.Models.Size", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Clothings_Store.Models.Staff", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Clothings_Store.Models.Stock", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
