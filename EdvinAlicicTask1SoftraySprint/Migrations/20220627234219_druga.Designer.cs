﻿// <auto-generated />
using EdvinAlicicTask1SoftraySprint.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EdvinAlicicTask1SoftraySprint.Migrations
{
    [DbContext(typeof(SongInfoContext))]
    [Migration("20220627234219_druga")]
    partial class druga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("EdvinAlicicTask1SoftraySprint.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pop"
                        });
                });

            modelBuilder.Entity("EdvinAlicicTask1SoftraySprint.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("authorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<int>("rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("songName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("songUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("EdvinAlicicTask1SoftraySprint.Entities.Song", b =>
                {
                    b.HasOne("EdvinAlicicTask1SoftraySprint.Entities.Category", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EdvinAlicicTask1SoftraySprint.Entities.Category", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
