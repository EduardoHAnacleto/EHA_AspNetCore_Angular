﻿// <auto-generated />
using System;
using EHA_AspNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EHA_AspNetCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231203214752_RemoveCustomerIntType")]
    partial class RemoveCustomerIntType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("BillToReceiveSequence");

            modelBuilder.HasSequence("IdentificationSequence");

            modelBuilder.Entity("EHA_AspNetCore.Models.Bills.BillToPay", b =>
                {
                    b.Property<int>("BillModel")
                        .HasColumnType("int");

                    b.Property<int>("BillNumber")
                        .HasColumnType("int");

                    b.Property<int>("BillSeries")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("InstalmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("CancellationMotive")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2");

                    b.Property<decimal>("ValuePaid")
                        .HasColumnType("decimal(10,2");

                    b.HasKey("BillModel", "BillNumber", "BillSeries", "SupplierId", "InstalmentNumber");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SupplierId");

                    b.ToTable("BillsToPay", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Bills.BillToReceive", b =>
                {
                    b.Property<int>("InstalmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [BillToReceiveSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("CancellationMotive")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2");

                    b.Property<decimal>("ValuePaid")
                        .HasColumnType("decimal(10,2");

                    b.HasKey("InstalmentNumber", "Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SaleId");

                    b.ToTable("BillsToReceive", (string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Payments.Instalment", b =>
                {
                    b.Property<int>("PaymentConditionId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Days")
                        .HasMaxLength(365)
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentage")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(5,2");

                    b.HasKey("PaymentConditionId", "Number");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Instalments", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Purchases.ItemPurchase", b =>
                {
                    b.Property<int>("PurchaseBillModel")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseBillNumber")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseBillSeries")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseSupplierId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5,2");

                    b.Property<decimal>("ProductValue")
                        .HasColumnType("decimal(10,2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PurchaseBillModel", "PurchaseBillNumber", "PurchaseBillSeries", "PurchaseSupplierId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ItemsPurchase", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Purchases.Purchase", b =>
                {
                    b.Property<int>("BillModel")
                        .HasColumnType("int");

                    b.Property<int>("BillNumber")
                        .HasColumnType("int");

                    b.Property<int>("BillSeries")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CancellationMotive")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExtraExpenses")
                        .HasColumnType("decimal(10,2");

                    b.Property<decimal>("FreightValue")
                        .HasColumnType("decimal(10,2");

                    b.Property<decimal>("InsuranceValue")
                        .HasColumnType("decimal(10,2");

                    b.Property<int>("PaymentConditionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2");

                    b.HasKey("BillModel", "BillNumber", "BillSeries", "SupplierId");

                    b.HasIndex("PaymentConditionId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchases", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Sales.ItemSale", b =>
                {
                    b.Property<int>("ItemSaleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CancelledDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5,2");

                    b.Property<decimal>("ProductValue")
                        .HasColumnType("decimal(10,2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("ItemSaleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("ItemsSale", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore_Angular.Models.Base.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [IdentificationSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Payments.PaymentCondition", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5,2");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(5,2");

                    b.Property<decimal>("Fine")
                        .HasColumnType("decimal(5,2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("PaymentConditions", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Payments.PaymentMethod", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("PaymentMethods", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.People.Customer", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("AddressAddition")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("BuildingNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PaymentConditionId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Street")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("PaymentConditionId");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.People.Supplier", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("AddressAddition")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("BuildingNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PaymentConditionId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SocialReason")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StateInscription")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("PaymentConditionId");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Sales.Sale", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CancellationMotive")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentConditionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentConditionId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore_Angular.Models.Products.Brand", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore_Angular.Models.Products.Category", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore_Angular.Models.Products.Product", b =>
                {
                    b.HasBaseType("EHA_AspNetCore_Angular.Models.Base.Identification");

                    b.Property<string>("Barcode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Bills.BillToPay", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.People.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Purchases.Purchase", "Purchase")
                        .WithMany()
                        .HasForeignKey("BillModel", "BillNumber", "BillSeries", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("Purchase");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Bills.BillToReceive", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.People.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Sales.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Payments.Instalment", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentCondition", null)
                        .WithMany("InstalmentList")
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Purchases.ItemPurchase", b =>
                {
                    b.HasOne("EHA_AspNetCore_Angular.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Purchases.Purchase", null)
                        .WithMany("ItemPurchaseList")
                        .HasForeignKey("PurchaseBillModel", "PurchaseBillNumber", "PurchaseBillSeries", "PurchaseSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Purchases.Purchase", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentCondition", "PaymentCondition")
                        .WithMany()
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.People.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentCondition");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Sales.ItemSale", b =>
                {
                    b.HasOne("EHA_AspNetCore_Angular.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Sales.Sale", null)
                        .WithMany("SaleItemsList")
                        .HasForeignKey("SaleId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.People.Customer", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentCondition", "PaymentCondition")
                        .WithMany()
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentCondition");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.People.Supplier", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentCondition", "PaymentCondition")
                        .WithMany()
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentCondition");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Sales.Sale", b =>
                {
                    b.HasOne("EHA_AspNetCore.Models.People.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore.Models.Payments.PaymentCondition", "PaymentCondition")
                        .WithMany()
                        .HasForeignKey("PaymentConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PaymentCondition");
                });

            modelBuilder.Entity("EHA_AspNetCore_Angular.Models.Products.Product", b =>
                {
                    b.HasOne("EHA_AspNetCore_Angular.Models.Products.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EHA_AspNetCore_Angular.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Purchases.Purchase", b =>
                {
                    b.Navigation("ItemPurchaseList");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Payments.PaymentCondition", b =>
                {
                    b.Navigation("InstalmentList");
                });

            modelBuilder.Entity("EHA_AspNetCore.Models.Sales.Sale", b =>
                {
                    b.Navigation("SaleItemsList");
                });
#pragma warning restore 612, 618
        }
    }
}
