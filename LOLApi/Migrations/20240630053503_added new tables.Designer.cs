﻿// <auto-generated />
using System;
using LOLApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LOLApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240630053503_added new tables")]
    partial class addednewtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LOLApi.Model.AdaptiveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdaptiveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdaptiveTypes");
                });

            modelBuilder.Entity("LOLApi.Model.Champion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdaptiveId")
                        .HasColumnType("int");

                    b.Property<string>("ChampionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int?>("RangeId")
                        .HasColumnType("int");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("championDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("championImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("championTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdaptiveId");

                    b.HasIndex("ClassId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RangeId");

                    b.HasIndex("RegionId");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionAbilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("championId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("championId");

                    b.ToTable("ChampionsAbilities");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChampionClasses");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChampionsPositions");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChampionsRegion");
                });

            modelBuilder.Entity("LOLApi.Model.RangeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RangeTypes");
                });

            modelBuilder.Entity("LOLApi.Model.Champion", b =>
                {
                    b.HasOne("LOLApi.Model.AdaptiveType", "adaptiveType")
                        .WithMany("Champions")
                        .HasForeignKey("AdaptiveId");

                    b.HasOne("LOLApi.Model.ChampionClass", "championClass")
                        .WithMany("Champions")
                        .HasForeignKey("ClassId");

                    b.HasOne("LOLApi.Model.ChampionPosition", "championPosition")
                        .WithMany("Champions")
                        .HasForeignKey("PositionId");

                    b.HasOne("LOLApi.Model.RangeType", "rangeType")
                        .WithMany("Champions")
                        .HasForeignKey("RangeId");

                    b.HasOne("LOLApi.Model.ChampionRegion", "championRegion")
                        .WithMany("Champions")
                        .HasForeignKey("RegionId");

                    b.Navigation("adaptiveType");

                    b.Navigation("championClass");

                    b.Navigation("championPosition");

                    b.Navigation("championRegion");

                    b.Navigation("rangeType");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionAbilities", b =>
                {
                    b.HasOne("LOLApi.Model.Champion", "Champion")
                        .WithMany("championAbilities")
                        .HasForeignKey("championId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Champion");
                });

            modelBuilder.Entity("LOLApi.Model.AdaptiveType", b =>
                {
                    b.Navigation("Champions");
                });

            modelBuilder.Entity("LOLApi.Model.Champion", b =>
                {
                    b.Navigation("championAbilities");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionClass", b =>
                {
                    b.Navigation("Champions");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionPosition", b =>
                {
                    b.Navigation("Champions");
                });

            modelBuilder.Entity("LOLApi.Model.ChampionRegion", b =>
                {
                    b.Navigation("Champions");
                });

            modelBuilder.Entity("LOLApi.Model.RangeType", b =>
                {
                    b.Navigation("Champions");
                });
#pragma warning restore 612, 618
        }
    }
}
