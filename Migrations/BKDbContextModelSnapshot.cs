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

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal?>("PriceL")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal?>("PriceXL")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");
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

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CestlheureduBK.Model.PromotionDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("CestlheureduBK.Model.RestaurantDb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressFull")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Departement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Opened")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("CestlheureduBK.Model.UpdateDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Catalogue")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("CestlheureduBK.Model.MenuDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CestlheureduBK.Model.OfferDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.PromotionDb", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("CestlheureduBK.Model.ProductDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("CestlheureduBK.Model.PromotionDb", b =>
                {
                    b.HasOne("CestlheureduBK.Model.RestaurantDb", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
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
#pragma warning restore 612, 618
        }
    }
}
