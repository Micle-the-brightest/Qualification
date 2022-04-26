﻿// <auto-generated />
using Dormitory.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dormitory.Migrations
{
    [DbContext(typeof(DormitoryContext))]
    [Migration("20220424142847_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dormitory.Entityes.Dormitory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BuldingName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FreeBedCount")
                        .HasColumnType("integer");

                    b.Property<int>("PersonCount")
                        .HasColumnType("integer");

                    b.Property<int>("PostIndex")
                        .HasColumnType("integer");

                    b.Property<int>("RoomCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dormitories");
                });
#pragma warning restore 612, 618
        }
    }
}
