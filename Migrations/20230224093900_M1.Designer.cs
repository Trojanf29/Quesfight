﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuesFight.Data;

#nullable disable

namespace QuesFight.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230224093900_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuesFight.Data.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("VARCHAR(45)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.Collection_Question", b =>
                {
                    b.Property<string>("QuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "CollectionId");

                    b.HasIndex("CollectionId");

                    b.ToTable("Collection_Question");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.LearnRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedQuestion")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinishTime")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("QuesCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("VARCHAR(45)");

                    b.HasKey("Id");

                    b.HasIndex("QuesCollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("LearnRecords");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.MatchRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedQuestion")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinishTime")
                        .HasColumnType("int");

                    b.Property<string>("PlayerId")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("QuesMatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("QuesMatchId");

                    b.ToTable("MatchRecords");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.QuesCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(45)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfQuestion")
                        .HasColumnType("int");

                    b.Property<int>("RestrictTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuesCollections");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.QuesMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuesCollectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WinnerId")
                        .HasColumnType("VARCHAR(45)");

                    b.HasKey("Id");

                    b.HasIndex("QuesCollectionId");

                    b.HasIndex("WinnerId");

                    b.ToTable("QuesMatch");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Choice1")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Choice2")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Choice3")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("CorrectChoice")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.QuestionGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(45)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("QuesFight.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Avatar")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Bio")
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("Token")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(45)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuesFight.Data.Message", b =>
                {
                    b.HasOne("QuesFight.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.Collection_Question", b =>
                {
                    b.HasOne("QuesFight.Data.QuestionData.QuesCollection", "QuesCollection")
                        .WithMany("Collection_Questions")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesFight.Data.QuestionData.Question", "Question")
                        .WithMany("Collection_Questions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuesCollection");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.LearnRecord", b =>
                {
                    b.HasOne("QuesFight.Data.QuestionData.QuesCollection", "QuesCollection")
                        .WithMany()
                        .HasForeignKey("QuesCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesFight.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("QuesCollection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.MatchRecord", b =>
                {
                    b.HasOne("QuesFight.Data.User", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("QuesFight.Data.QuestionData.QuesMatch", "QuesMatch")
                        .WithMany()
                        .HasForeignKey("QuesMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("QuesMatch");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.QuesMatch", b =>
                {
                    b.HasOne("QuesFight.Data.QuestionData.QuesCollection", "QuesCollection")
                        .WithMany()
                        .HasForeignKey("QuesCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesFight.Data.User", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("QuesCollection");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.Question", b =>
                {
                    b.HasOne("QuesFight.Data.QuestionData.QuestionGenre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.QuesCollection", b =>
                {
                    b.Navigation("Collection_Questions");
                });

            modelBuilder.Entity("QuesFight.Data.QuestionData.Question", b =>
                {
                    b.Navigation("Collection_Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
