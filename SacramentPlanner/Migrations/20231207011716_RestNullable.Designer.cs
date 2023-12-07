﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentPlanner.Data;

#nullable disable

namespace SacramentPlanner.Migrations
{
    [DbContext(typeof(SacramentPlannerContext))]
    [Migration("20231207011716_RestNullable")]
    partial class RestNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("SacramentPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClosingHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClosingPrayer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Conductor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("OpeningHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpeningPrayer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RestHymn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SacramentHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecialMusicalNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("TalksJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WardName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Meeting");
                });
#pragma warning restore 612, 618
        }
    }
}
