﻿// <auto-generated />
using Mentorium;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mentorium.Migrations
{
    [DbContext(typeof(MentoriumDbContext))]
    [Migration("20240407085943_FixId")]
    partial class FixId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mentorium.DataAccess.GithubUser", b =>
                {
                    b.Property<int>("GithubUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GithubUserId"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("GithubUserId");

                    b.HasIndex("UserId");

                    b.ToTable("GithubUsers");
                });

            modelBuilder.Entity("Mentorium.DataAccess.MentorInfo", b =>
                {
                    b.Property<int>("MentorInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MentorInfoId"));

                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MentorInfoId");

                    b.ToTable("MentorInfo");
                });

            modelBuilder.Entity("Mentorium.DataAccess.MentorInfoStack", b =>
                {
                    b.Property<int>("MentorInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("StackId")
                        .HasColumnType("integer");

                    b.HasKey("MentorInfoId", "StackId");

                    b.HasIndex("StackId");

                    b.ToTable("MentorInfoStacks");
                });

            modelBuilder.Entity("Mentorium.DataAccess.MentoriumStacks", b =>
                {
                    b.Property<int>("MentoriumStacksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MentoriumStacksId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MentoriumStacksId");

                    b.ToTable("Stacks");
                });

            modelBuilder.Entity("Mentorium.DataAccess.StudentInfo", b =>
                {
                    b.Property<int>("StudentInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentInfoId"));

                    b.HasKey("StudentInfoId");

                    b.ToTable("StudentInfo");
                });

            modelBuilder.Entity("Mentorium.DataAccess.StudentInfoStack", b =>
                {
                    b.Property<int>("StudentInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("StackId")
                        .HasColumnType("integer");

                    b.HasKey("StudentInfoId", "StackId");

                    b.HasIndex("StackId");

                    b.ToTable("StudentInfoStacksStack");
                });

            modelBuilder.Entity("Mentorium.DataAccess.TelegramUser", b =>
                {
                    b.Property<int>("TelegramUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TelegramUserId"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("TelegramUserId");

                    b.HasIndex("UserId");

                    b.ToTable("TelegramUsers");
                });

            modelBuilder.Entity("Mentorium.DataAccess.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Descriotion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MentorInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentInfoId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("MentorInfoId");

                    b.HasIndex("StudentInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mentorium.DataAccess.GithubUser", b =>
                {
                    b.HasOne("Mentorium.DataAccess.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mentorium.DataAccess.MentorInfoStack", b =>
                {
                    b.HasOne("Mentorium.DataAccess.MentorInfo", "MentorInfo")
                        .WithMany()
                        .HasForeignKey("MentorInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentorium.DataAccess.MentoriumStacks", "Stack")
                        .WithMany()
                        .HasForeignKey("StackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MentorInfo");

                    b.Navigation("Stack");
                });

            modelBuilder.Entity("Mentorium.DataAccess.StudentInfoStack", b =>
                {
                    b.HasOne("Mentorium.DataAccess.MentoriumStacks", "Stack")
                        .WithMany()
                        .HasForeignKey("StackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentorium.DataAccess.StudentInfo", "StudentInfo")
                        .WithMany()
                        .HasForeignKey("StudentInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stack");

                    b.Navigation("StudentInfo");
                });

            modelBuilder.Entity("Mentorium.DataAccess.TelegramUser", b =>
                {
                    b.HasOne("Mentorium.DataAccess.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mentorium.DataAccess.User", b =>
                {
                    b.HasOne("Mentorium.DataAccess.MentorInfo", "MentorInfo")
                        .WithMany()
                        .HasForeignKey("MentorInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentorium.DataAccess.StudentInfo", "StudentInfo")
                        .WithMany()
                        .HasForeignKey("StudentInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MentorInfo");

                    b.Navigation("StudentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
