﻿// <auto-generated />
using System;
using Battleship.Webapi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Battleship.Webapi.Migrations
{
    [DbContext(typeof(PlayerDbContext))]
    [Migration("20220517041858_StatsUpdate")]
    partial class StatsUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Battleship.Logic.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GridId")
                        .HasColumnType("int");

                    b.Property<int?>("shipId")
                        .HasColumnType("int");

                    b.Property<int>("touched")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("shipId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Grid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dimensions")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerOwnerId");

                    b.ToTable("Grids");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Orientation")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Grid1IdId")
                        .HasColumnType("int");

                    b.Property<int?>("Grid2IdId")
                        .HasColumnType("int");

                    b.Property<int?>("Player1IdId")
                        .HasColumnType("int");

                    b.Property<int>("Player1shots")
                        .HasColumnType("int");

                    b.Property<int?>("Player2IdId")
                        .HasColumnType("int");

                    b.Property<int>("Player2shots")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Grid1IdId");

                    b.HasIndex("Grid2IdId");

                    b.HasIndex("Player1IdId");

                    b.HasIndex("Player2IdId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Cell", b =>
                {
                    b.HasOne("Battleship.Logic.Models.Ship", "ship")
                        .WithMany()
                        .HasForeignKey("shipId");

                    b.Navigation("ship");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Grid", b =>
                {
                    b.HasOne("Battleship.Logic.Models.Player", "PlayerOwner")
                        .WithMany()
                        .HasForeignKey("PlayerOwnerId");

                    b.Navigation("PlayerOwner");
                });

            modelBuilder.Entity("Battleship.Logic.Models.Stats", b =>
                {
                    b.HasOne("Battleship.Logic.Models.Grid", "Grid1Id")
                        .WithMany()
                        .HasForeignKey("Grid1IdId");

                    b.HasOne("Battleship.Logic.Models.Grid", "Grid2Id")
                        .WithMany()
                        .HasForeignKey("Grid2IdId");

                    b.HasOne("Battleship.Logic.Models.Player", "Player1Id")
                        .WithMany()
                        .HasForeignKey("Player1IdId");

                    b.HasOne("Battleship.Logic.Models.Player", "Player2Id")
                        .WithMany()
                        .HasForeignKey("Player2IdId");

                    b.Navigation("Grid1Id");

                    b.Navigation("Grid2Id");

                    b.Navigation("Player1Id");

                    b.Navigation("Player2Id");
                });
#pragma warning restore 612, 618
        }
    }
}
