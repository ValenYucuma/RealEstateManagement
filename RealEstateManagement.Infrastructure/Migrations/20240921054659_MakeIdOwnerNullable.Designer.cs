﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateManagement.Infrastructure.Data;

#nullable disable

namespace RealEstateManagement.Infrastructure.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    [Migration("20240921054659_MakeIdOwnerNullable")]
    partial class MakeIdOwnerNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.Owner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOwner"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdOwner");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.Property", b =>
                {
                    b.Property<int>("IdProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProperty"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeInternal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdProperty");

                    b.HasIndex("IdOwner");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.PropertyImage", b =>
                {
                    b.Property<int>("IdPropertyImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropertyImage"));

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.HasKey("IdPropertyImage");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyImages");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.PropertyTrace", b =>
                {
                    b.Property<int>("IdPropertyTrace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropertyTrace"));

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdPropertyTrace");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyTraces");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.Property", b =>
                {
                    b.HasOne("RealEstateManagement.Domain.Entities.Owner", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.PropertyImage", b =>
                {
                    b.HasOne("RealEstateManagement.Domain.Entities.Property", "Property")
                        .WithMany("PropertyImages")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.PropertyTrace", b =>
                {
                    b.HasOne("RealEstateManagement.Domain.Entities.Property", "Property")
                        .WithMany("PropertyPrices")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("RealEstateManagement.Domain.Entities.Property", b =>
                {
                    b.Navigation("PropertyImages");

                    b.Navigation("PropertyPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
