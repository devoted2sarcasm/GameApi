﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GameApi.Repositories;

#nullable disable

namespace GameApi.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20240426004521_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameApi.Models.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int?>("IdealPlayerCount")
                        .HasColumnType("int");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Playtime")
                        .HasColumnType("int");

                    b.Property<int?>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Collect resources and build settlements",
                            Difficulty = 2,
                            IdealPlayerCount = 4,
                            MaxPlayers = 4,
                            MinPlayers = 3,
                            Name = "Catan",
                            Playtime = 60,
                            Rank = 4
                        },
                        new
                        {
                            Id = 2,
                            Description = "Collect train cards and build routes",
                            Difficulty = 1,
                            IdealPlayerCount = 4,
                            MaxPlayers = 5,
                            MinPlayers = 2,
                            Name = "Ticket to Ride",
                            Playtime = 45,
                            Rank = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Build your city and earn coins",
                            Difficulty = 1,
                            IdealPlayerCount = 3,
                            MaxPlayers = 5,
                            MinPlayers = 2,
                            Name = "Machi Koro 2",
                            Playtime = 30,
                            Rank = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Push your luck and brew potions",
                            Difficulty = 2,
                            IdealPlayerCount = 4,
                            MaxPlayers = 4,
                            MinPlayers = 2,
                            Name = "Quacks of Quedlinburg",
                            Playtime = 45,
                            Rank = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Collect gems and build your empire",
                            Difficulty = 1,
                            IdealPlayerCount = 3,
                            MaxPlayers = 4,
                            MinPlayers = 2,
                            Name = "Splendor",
                            Playtime = 30,
                            Rank = 5
                        },
                        new
                        {
                            Id = 6,
                            Description = "Guess the word and win the round",
                            Difficulty = 1,
                            IdealPlayerCount = 6,
                            MaxPlayers = 99,
                            MinPlayers = 3,
                            Name = "Word Slam",
                            Playtime = 45,
                            Rank = 6
                        },
                        new
                        {
                            Id = 7,
                            Description = "Find the spies and save the world",
                            Difficulty = 1,
                            IdealPlayerCount = 7,
                            MaxPlayers = 10,
                            MinPlayers = 5,
                            Name = "The Resistance",
                            Playtime = 30,
                            Rank = 7
                        },
                        new
                        {
                            Id = 8,
                            Description = "Place tiles and stay on the board to be the last one standing",
                            Difficulty = 1,
                            IdealPlayerCount = 5,
                            MaxPlayers = 8,
                            MinPlayers = 2,
                            Name = "Tsuro",
                            Playtime = 15,
                            Rank = 8
                        },
                        new
                        {
                            Id = 9,
                            Description = "Work together to collect treasures and escape the island",
                            Difficulty = 1,
                            IdealPlayerCount = 4,
                            MaxPlayers = 4,
                            MinPlayers = 2,
                            Name = "Forbidden Island",
                            Playtime = 30,
                            Rank = 9
                        },
                        new
                        {
                            Id = 10,
                            Description = "Pirate your way to the most loot",
                            Difficulty = 1,
                            IdealPlayerCount = 6,
                            MaxPlayers = 8,
                            MinPlayers = 2,
                            Name = "Loot",
                            Playtime = 30,
                            Rank = 10
                        },
                        new
                        {
                            Id = 11,
                            Description = "Roll dice and fill in your sheet to earn the highest score",
                            Difficulty = 1,
                            IdealPlayerCount = 3,
                            MaxPlayers = 4,
                            MinPlayers = 1,
                            Name = "That's So Clever",
                            Playtime = 30,
                            Rank = 11
                        });
                });

            modelBuilder.Entity("GameApi.Models.GamePlayed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("Players")
                        .HasColumnType("int");

                    b.Property<string>("Timestamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.ToTable("GamesPlayed");
                });

            modelBuilder.Entity("GameApi.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GamePlayedId")
                        .HasColumnType("int");

                    b.Property<string>("Player")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayedId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("GameApi.Models.GamePlayed", b =>
                {
                    b.HasOne("GameApi.Models.BoardGame", "BoardGame")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");
                });

            modelBuilder.Entity("GameApi.Models.Score", b =>
                {
                    b.HasOne("GameApi.Models.GamePlayed", "GamePlayed")
                        .WithMany()
                        .HasForeignKey("GamePlayedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlayed");
                });

            modelBuilder.Entity("GameApi.Models.BoardGame", b =>
                {
                    b.Navigation("GamesPlayed");
                });
#pragma warning restore 612, 618
        }
    }
}
