﻿// <auto-generated />
using System;
using ITEC_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITEC_API.Migrations
{
    [DbContext(typeof(ITECDbContext))]
    [Migration("20241106113241_Course")]
    partial class Course
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITEC_API.Models.CourseLevel", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("MainCourseId");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("ITEC_API.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITEC_API.Models.InstructorEnrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.MainCourse", b =>
                {
                    b.Property<int>("MainCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainCourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainCourseId");

                    b.ToTable("MainCourses");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseLevel", b =>
                {
                    b.HasOne("ITEC_API.Models.MainCourse", "MainCourse")
                        .WithMany("CourseLevels")
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCourse");
                });

            modelBuilder.Entity("ITEC_API.Models.InstructorEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseLevel", "CourseLevel")
                        .WithMany("InstructorEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.Instructor", "Instructor")
                        .WithMany("InstructorEnrollments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseLevel", b =>
                {
                    b.Navigation("InstructorEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.Instructor", b =>
                {
                    b.Navigation("InstructorEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.MainCourse", b =>
                {
                    b.Navigation("CourseLevels");
                });
#pragma warning restore 612, 618
        }
    }
}