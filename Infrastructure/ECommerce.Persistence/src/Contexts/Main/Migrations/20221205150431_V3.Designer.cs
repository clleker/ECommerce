﻿// <auto-generated />
using System;
using ECommerce.Persistence.Contexts.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20221205150431_V3")]
    partial class V3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Domain.Entities.AttributeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("AttributeGroups");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Attribute_", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductAttributeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttributeGroupId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributeGroup");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCardAttributeId")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCardAttributeId")
                        .IsUnique();

                    b.ToTable("ProductCards");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ProductAttributeGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductAttributeGroupId");

                    b.ToTable("ProductCardAttributes");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProductCardId");

                    b.ToTable("ProductCardPicture");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("IncludingVatPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCardId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCardId")
                        .IsUnique();

                    b.ToTable("ProductCardPrices");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Nop.Core.Domain.Catalog.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Category", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductAttributeGroup", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany("ProductAttributeGroups")
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Entities.Product", "Product")
                        .WithMany("ProductAttributeGroups")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeGroup");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCard", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.ProductCardAttribute", "ProductCardAttribute")
                        .WithOne("ProductCard")
                        .HasForeignKey("ECommerce.Domain.Entities.ProductCard", "ProductCardAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCardAttribute");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardAttribute", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Attribute_", "Attribute")
                        .WithMany("ProductCardAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Entities.ProductAttributeGroup", "ProductAttributeGroup")
                        .WithMany("ProductCardAttributes")
                        .HasForeignKey("ProductAttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("ProductAttributeGroup");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardPicture", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Picture", "Picture")
                        .WithMany("ProductCardPictures")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Entities.ProductCard", "ProductCard")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("ProductCard");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardPrice", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.ProductCard", "ProductCard")
                        .WithOne("ProductCardPrice")
                        .HasForeignKey("ECommerce.Domain.Entities.ProductCardPrice", "ProductCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCard");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nop.Core.Domain.Catalog.Specification", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Product", null)
                        .WithMany("ProductSpecifications")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.AttributeGroup", b =>
                {
                    b.Navigation("ProductAttributeGroups");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Attribute_", b =>
                {
                    b.Navigation("ProductCardAttributes");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Picture", b =>
                {
                    b.Navigation("ProductCardPictures");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductAttributeGroups");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductSpecifications");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductAttributeGroup", b =>
                {
                    b.Navigation("ProductCardAttributes");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCard", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("ProductCardPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardAttribute", b =>
                {
                    b.Navigation("ProductCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
