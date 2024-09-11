﻿// <auto-generated />
using System;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CestlheureduBK.Migrations
{
    [DbContext(typeof(BKDbContext))]
    partial class BKDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("CategorieDbMenuDb", b =>
                {
                    b.Property<string>("CategoriesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MenusId")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriesId", "MenusId");

                    b.HasIndex("MenusId");

                    b.ToTable("CategorieDbMenuDb");
                });

            modelBuilder.Entity("CategorieDbProductDb", b =>
                {
                    b.Property<string>("CategoriesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategorieDbProductDb");
                });

            modelBuilder.Entity("CestlheureduBK.Model.CategorieDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SubCategory")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CestlheureduBK.Model.MenuDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AvailableInCatalogue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CestlheureduBK.Model.MenuRestaurantDb", b =>
                {
                    b.Property<string>("MenuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<double?>("PriceL")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<double?>("PriceXL")
                        .HasColumnType("decimal(4, 2)");

                    b.HasKey("MenuId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenusRestaurants");
                });

            modelBuilder.Entity("CestlheureduBK.Model.OfferDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromotionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CestlheureduBK.Model.ProductDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AvailableInCatalogue")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Energy")
                        .HasColumnType("decimal(7, 2)");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CestlheureduBK.Model.ProductRestaurantDb", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(4, 2)");

                    b.HasKey("ProductId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("ProductsRestaurants");
                });

            modelBuilder.Entity("CestlheureduBK.Model.PromotionDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("CestlheureduBK.Model.PromotionRestaurantDb", b =>
                {
                    b.Property<string>("PromotionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.HasKey("PromotionId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("PromotionsRestaurants");
                });

            modelBuilder.Entity("CestlheureduBK.Model.RestaurantDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressFull")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CatalogueUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Departement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Lat")
                        .HasColumnType("REAL");

                    b.Property<double>("Lng")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Opened")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("CestlheureduBK.Model.SnackAmountDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MenuDbId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductDbId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SnackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MenuDbId");

                    b.HasIndex("ProductDbId");

                    b.HasIndex("SnackId");

                    b.ToTable("SnackAmounts");
                });

            modelBuilder.Entity("CestlheureduBK.Model.SnackDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Snacks");
                });

            modelBuilder.Entity("CestlheureduBK.Model.StepDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DefaultProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MenuDbId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DefaultProductId");

                    b.HasIndex("MenuDbId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("CestlheureduBK.Model.UpdateDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Offers")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Restaurants")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Update");
                });

            modelBuilder.Entity("MenuDbPromotionDb", b =>
                {
                    b.Property<string>("MenusId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PromotionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("MenusId", "PromotionsId");

                    b.HasIndex("PromotionsId");

                    b.ToTable("MenuDbPromotionDb");
                });

            modelBuilder.Entity("ProductDbPromotionDb", b =>
                {
                    b.Property<string>("ProductsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PromotionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductsId", "PromotionsId");

                    b.HasIndex("PromotionsId");

                    b.ToTable("ProductDbPromotionDb");
                });

            modelBuilder.Entity("StepProducts", b =>
                {
                    b.Property<string>("ProductsId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StepDbId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductsId", "StepDbId");

                    b.HasIndex("StepDbId");

                    b.ToTable("StepProducts");
                });

            modelBuilder.Entity("StepProductsL", b =>
                {
                    b.Property<string>("ProductsLId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StepDb1Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductsLId", "StepDb1Id");

                    b.HasIndex("StepDb1Id");

                    b.ToTable("StepProductsL");
                });

            modelBuilder.Entity("StepProductsXL", b =>
                {
                    b.Property<string>("ProductsXLId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StepDb2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductsXLId", "StepDb2Id");

                    b.HasIndex("StepDb2Id");

                    b.ToTable("StepProductsXL");
                });

            modelBuilder.Entity("CategorieDbMenuDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.CategorieDb", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.MenuDb", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategorieDbProductDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.CategorieDb", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CestlheureduBK.Model.MenuRestaurantDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.MenuDb", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CestlheureduBK.Model.OfferDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.PromotionDb", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("CestlheureduBK.Model.ProductRestaurantDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CestlheureduBK.Model.PromotionRestaurantDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.PromotionDb", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CestlheureduBK.Model.SnackAmountDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.MenuDb", null)
                        .WithMany("Snacks")
                        .HasForeignKey("MenuDbId");

                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany("Snacks")
                        .HasForeignKey("ProductDbId");

                    b.HasOne("CestlheureduBK.Model.SnackDb", "Snack")
                        .WithMany()
                        .HasForeignKey("SnackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Snack");
                });

            modelBuilder.Entity("CestlheureduBK.Model.StepDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", "DefaultProduct")
                        .WithMany()
                        .HasForeignKey("DefaultProductId");

                    b.HasOne("CestlheureduBK.Model.MenuDb", null)
                        .WithMany("Steps")
                        .HasForeignKey("MenuDbId");

                    b.Navigation("DefaultProduct");
                });

            modelBuilder.Entity("MenuDbPromotionDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.MenuDb", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.PromotionDb", null)
                        .WithMany()
                        .HasForeignKey("PromotionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductDbPromotionDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.PromotionDb", null)
                        .WithMany()
                        .HasForeignKey("PromotionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StepProducts", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.StepDb", null)
                        .WithMany()
                        .HasForeignKey("StepDbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StepProductsL", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany()
                        .HasForeignKey("ProductsLId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.StepDb", null)
                        .WithMany()
                        .HasForeignKey("StepDb1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StepProductsXL", b =>
                {
                    b.HasOne("CestlheureduBK.Model.ProductDb", null)
                        .WithMany()
                        .HasForeignKey("ProductsXLId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CestlheureduBK.Model.StepDb", null)
                        .WithMany()
                        .HasForeignKey("StepDb2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CestlheureduBK.Model.MenuDb", b =>
                {
                    b.Navigation("Snacks");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("CestlheureduBK.Model.ProductDb", b =>
                {
                    b.Navigation("Snacks");
                });
#pragma warning restore 612, 618
        }
    }
}
