﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsPortal.WebAppApi.Data;

#nullable disable

namespace NewsPortal.WebAppApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewsPortal.WebAppApi.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NewsPortal.WebAppApi.Models.News", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsTrending")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ImageId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CategoryID = "1",
                            Content = "A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = false,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Residents Urged to Stay Safe",
                            Title = "Earthquake Shakes California"
                        },
                        new
                        {
                            Id = "2",
                            CategoryID = "2",
                            Content = "A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = false,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Health Officials Monitor Situation",
                            Title = "New COVID-19 Variant Detected"
                        },
                        new
                        {
                            Id = "3",
                            CategoryID = "3",
                            Content = "Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = true,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "Features High-Resolution Camera",
                            Title = "Tech Giant Launches New Smartphone"
                        },
                        new
                        {
                            Id = "4",
                            CategoryID = "3",
                            Content = "Apple has just announced the iPhone 14 Pro Max, featuring a revolutionary foldable display and an AI-powered camera system. This device promises to redefine the smartphone landscape with its innovative features and sleek design.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = true,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "A Game-Changer in Smartphone Technology",
                            Title = "Apple Unveils the Latest iPhone 14 Pro Max"
                        },
                        new
                        {
                            Id = "5",
                            CategoryID = "3",
                            Content = "Google's quantum computing team has achieved a major milestone, demonstrating a quantum computer capable of solving complex problems faster than ever before. This breakthrough has the potential to impact fields such as cryptography, drug discovery, and climate modeling.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = true,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "A Leap Toward Solving Complex Problems",
                            Title = "Google's Quantum Computing Breakthrough"
                        },
                        new
                        {
                            Id = "6",
                            CategoryID = "3",
                            Content = "In a historic move, the U.S. government has officially granted Tesla permission to deploy fully autonomous vehicles on public highways. Tesla's Autopilot system has reached a level of reliability and safety that is paving the way for a future with self-driving cars.",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTrending = true,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtitle = "A New Era for Autonomous Vehicle",
                            Title = "Tesla's Self-Driving Cars Now Legal on U.S. Highways"
                        });
                });

            modelBuilder.Entity("NewsPortal.WebAppApi.Models.NewsCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("NewsCategories");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Nature"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Health"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Technology"
                        });
                });

            modelBuilder.Entity("NewsPortal.WebAppApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            EmailAddress = "admin@kft.hu",
                            IsAdmin = true,
                            Password = "1234",
                            UserName = "gipszjakab"
                        },
                        new
                        {
                            Id = "2",
                            EmailAddress = "onion@nasa.gov",
                            IsAdmin = false,
                            Password = "1234",
                            UserName = "shrek"
                        });
                });

            modelBuilder.Entity("NewsPortal.WebAppApi.Models.News", b =>
                {
                    b.HasOne("NewsPortal.WebAppApi.Models.NewsCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("NewsPortal.WebAppApi.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
