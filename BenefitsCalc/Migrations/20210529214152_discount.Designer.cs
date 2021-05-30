﻿// <auto-generated />
using System;
using BenefitsCalc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BenefitsCalc.Migrations
{
    [DbContext(typeof(BenefitsCalcContext))]
    [Migration("20210529214152_discount")]
    partial class discount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BenefitsCalc.Models.AppConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseBenefitsCost")
                        .HasColumnType("int");

                    b.Property<int>("DefaultSalary")
                        .HasColumnType("int");

                    b.Property<int>("DependentCost")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPct")
                        .HasColumnType("decimal(4,4)");

                    b.Property<int>("PayPeriods")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("BenefitsCalc.Models.Dependent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dependent");
                });

            modelBuilder.Entity("BenefitsCalc.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BenefitsCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("GrossPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NetPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isBenefitsDiscount")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}