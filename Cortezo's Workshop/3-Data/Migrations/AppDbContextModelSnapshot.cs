﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3___Data;

#nullable disable

namespace _3___Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_3___Data.Models.CommodityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalOre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Commodities");
                });

            modelBuilder.Entity("_3___Data.Models.GenericProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdMaterial")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Resources")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaterial");

                    b.ToTable("GenericProducts");
                });

            modelBuilder.Entity("_3___Data.Models.IngotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingots");
                });

            modelBuilder.Entity("_3___Data.Models.IngotResourceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommodityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FullPlatePrice")
                        .HasColumnType("int");

                    b.Property<int>("IdMaterial")
                        .HasColumnType("int");

                    b.Property<string>("IngotName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MapQuantity")
                        .HasColumnType("int");

                    b.Property<string>("MapRecommendedPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MapTotalOre")
                        .HasColumnType("int");

                    b.Property<int>("ToolPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaterial");

                    b.ToTable("IngotResources");
                });

            modelBuilder.Entity("_3___Data.Models.MaterialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("_3___Data.Models.OreMapModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RecommendedPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalOre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OreMaps");
                });

            modelBuilder.Entity("_3___Data.Models.ProductModels.FullPlateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FullPlates");
                });

            modelBuilder.Entity("_3___Data.Models.ProductModels.ToolModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("_3___Data.Models.ShopStatsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShopStats");
                });

            modelBuilder.Entity("_3___Data.Models.GenericProductModel", b =>
                {
                    b.HasOne("_3___Data.Models.MaterialModel", "Material")
                        .WithMany()
                        .HasForeignKey("IdMaterial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("_3___Data.Models.IngotResourceModel", b =>
                {
                    b.HasOne("_3___Data.Models.MaterialModel", "Material")
                        .WithMany()
                        .HasForeignKey("IdMaterial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });
#pragma warning restore 612, 618
        }
    }
}
