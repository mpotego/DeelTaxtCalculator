﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.DB;

#nullable disable

namespace TaxCalculator.DB.Migrations
{
    [DbContext(typeof(TaxCalculatorDbContext))]
    [Migration("20231212135306_the_genesis")]
    partial class the_genesis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CalculationResultPayRangeSetting", b =>
                {
                    b.Property<long>("CalculationResultsId")
                        .HasColumnType("bigint");

                    b.Property<long>("PayRangeSettingId")
                        .HasColumnType("bigint");

                    b.HasKey("CalculationResultsId", "PayRangeSettingId");

                    b.HasIndex("PayRangeSettingId");

                    b.ToTable("CalculationResultPayRangeSetting");
                });

            modelBuilder.Entity("CalculationResultPostalCode", b =>
                {
                    b.Property<long>("CalculationResultId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostalCodesId")
                        .HasColumnType("bigint");

                    b.HasKey("CalculationResultId", "PostalCodesId");

                    b.HasIndex("PostalCodesId");

                    b.ToTable("CalculationResultPostalCode");
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.CalculationResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PayAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PayRangeSettingId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostalCodeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CalculationResults");
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.CalculationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CalculationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Percentage",
                            Name = "Percentage"
                        },
                        new
                        {
                            Id = 2,
                            Description = "FlatRate",
                            Name = "FlatValue"
                        });
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.PayRangeSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("CalculationTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("CalculationValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("From")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("To")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CalculationTypeId");

                    b.HasIndex("TaxTypeId");

                    b.ToTable("PayRangeSettings");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CalculationTypeId = 1,
                            CalculationValue = 10m,
                            From = 0m,
                            TaxTypeId = 1,
                            To = 8350m
                        },
                        new
                        {
                            Id = 2L,
                            CalculationTypeId = 1,
                            CalculationValue = 15m,
                            From = 8351m,
                            TaxTypeId = 1,
                            To = 33950m
                        },
                        new
                        {
                            Id = 3L,
                            CalculationTypeId = 1,
                            CalculationValue = 25m,
                            From = 33951m,
                            TaxTypeId = 1,
                            To = 82250m
                        },
                        new
                        {
                            Id = 4L,
                            CalculationTypeId = 1,
                            CalculationValue = 28m,
                            From = 82251m,
                            TaxTypeId = 1,
                            To = 171550m
                        },
                        new
                        {
                            Id = 5L,
                            CalculationTypeId = 1,
                            CalculationValue = 33m,
                            From = 171551m,
                            TaxTypeId = 1,
                            To = 372950m
                        },
                        new
                        {
                            Id = 6L,
                            CalculationTypeId = 1,
                            CalculationValue = 35m,
                            From = 372951m,
                            TaxTypeId = 1
                        },
                        new
                        {
                            Id = 7L,
                            CalculationTypeId = 1,
                            CalculationValue = 5m,
                            From = 0m,
                            TaxTypeId = 3,
                            To = 199999m
                        },
                        new
                        {
                            Id = 8L,
                            CalculationTypeId = 2,
                            CalculationValue = 10000m,
                            From = 200000m,
                            TaxTypeId = 3
                        },
                        new
                        {
                            Id = 9L,
                            CalculationTypeId = 1,
                            CalculationValue = 17.5m,
                            From = 0m,
                            TaxTypeId = 2
                        });
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.PostalCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxTypeId");

                    b.ToTable("PostalCodes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "7441",
                            TaxTypeId = 1
                        },
                        new
                        {
                            Id = 2L,
                            Code = "1000",
                            TaxTypeId = 1
                        },
                        new
                        {
                            Id = 3L,
                            Code = "7000",
                            TaxTypeId = 2
                        },
                        new
                        {
                            Id = 4L,
                            Code = "A100",
                            TaxTypeId = 3
                        });
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.TaxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxtTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Progressive",
                            Name = "Progressive"
                        },
                        new
                        {
                            Id = 2,
                            Description = "FlatRate",
                            Name = "FlatRate"
                        },
                        new
                        {
                            Id = 3,
                            Description = "FlatValue",
                            Name = "FlatValue"
                        });
                });

            modelBuilder.Entity("CalculationResultPayRangeSetting", b =>
                {
                    b.HasOne("TaxCalculator.DB.Tables.CalculationResult", null)
                        .WithMany()
                        .HasForeignKey("CalculationResultsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculator.DB.Tables.PayRangeSetting", null)
                        .WithMany()
                        .HasForeignKey("PayRangeSettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalculationResultPostalCode", b =>
                {
                    b.HasOne("TaxCalculator.DB.Tables.CalculationResult", null)
                        .WithMany()
                        .HasForeignKey("CalculationResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculator.DB.Tables.PostalCode", null)
                        .WithMany()
                        .HasForeignKey("PostalCodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.PayRangeSetting", b =>
                {
                    b.HasOne("TaxCalculator.DB.Tables.CalculationType", "CalculationType")
                        .WithMany("PayRangeSettings")
                        .HasForeignKey("CalculationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaxCalculator.DB.Tables.TaxType", "TaxtType")
                        .WithMany("PayRangeSettings")
                        .HasForeignKey("TaxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalculationType");

                    b.Navigation("TaxtType");
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.PostalCode", b =>
                {
                    b.HasOne("TaxCalculator.DB.Tables.TaxType", "TaxType")
                        .WithMany("PostalCodes")
                        .HasForeignKey("TaxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxType");
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.CalculationType", b =>
                {
                    b.Navigation("PayRangeSettings");
                });

            modelBuilder.Entity("TaxCalculator.DB.Tables.TaxType", b =>
                {
                    b.Navigation("PayRangeSettings");

                    b.Navigation("PostalCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
