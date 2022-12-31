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
    [Migration("20221229195403_V13")]
    partial class V13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AuthGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthGroups");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AuthGroupRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthGroupId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthGroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("AuthGroupRoles");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.UserAuthGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthGroups");
                });

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmPhone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisterEmailConfirmDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.CustomerSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CustomerSettings");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDetail")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCardAttributeId")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AuthGroupRole", b =>
                {
                    b.HasOne("ECommerce.Core.Domain.AppUser.AuthGroup", "AuthGroup")
                        .WithMany("AuthGroupRoles")
                        .HasForeignKey("AuthGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.Domain.AppUser.AppRole", "Role")
                        .WithMany("AuthGroupRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthGroup");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.UserAuthGroup", b =>
                {
                    b.HasOne("ECommerce.Core.Domain.AppUser.AuthGroup", "AuthGroup")
                        .WithMany("UserAuthGroups")
                        .HasForeignKey("AuthGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.Domain.AppUser.AppUser", "User")
                        .WithMany("UserAuthGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.Category", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.CustomerSetting", b =>
                {
                    b.HasOne("ECommerce.Domain.Entities.Customer", "Customer")
                        .WithOne("CustomerSetting")
                        .HasForeignKey("ECommerce.Domain.Entities.CustomerSetting", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
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

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AppRole", b =>
                {
                    b.Navigation("AuthGroupRoles");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AppUser", b =>
                {
                    b.Navigation("UserAuthGroups");
                });

            modelBuilder.Entity("ECommerce.Core.Domain.AppUser.AuthGroup", b =>
                {
                    b.Navigation("AuthGroupRoles");

                    b.Navigation("UserAuthGroups");
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

            modelBuilder.Entity("ECommerce.Domain.Entities.Customer", b =>
                {
                    b.Navigation("CustomerSetting");
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

                    b.Navigation("ProductCardPrice");
                });

            modelBuilder.Entity("ECommerce.Domain.Entities.ProductCardAttribute", b =>
                {
                    b.Navigation("ProductCard");
                });
#pragma warning restore 612, 618
        }
    }
}
