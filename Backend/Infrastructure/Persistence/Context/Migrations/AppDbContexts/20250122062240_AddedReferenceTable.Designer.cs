﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Context.Migrations.AppDbContexts
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250122062240_AddedReferenceTable")]
    partial class AddedReferenceTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("degree");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<double>("Grading")
                        .HasColumnType("double precision")
                        .HasColumnName("grading");

                    b.Property<int>("GradingType")
                        .HasColumnType("integer")
                        .HasColumnName("grading_type");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("institution");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_current");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("personal_info_id");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_educations");

                    b.ToTable("educations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("duration");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("boolean")
                        .HasColumnName("is_current");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("personal_info_id");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_experiences");

                    b.ToTable("experiences", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PersonalInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Designations")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("designations");

                    b.Property<string>("Details")
                        .HasColumnType("text")
                        .HasColumnName("details");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.PrimitiveCollection<string[]>("Hobbies")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("hobbies");

                    b.PrimitiveCollection<string[]>("Languages")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("languages");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("Middlename")
                        .HasColumnType("text")
                        .HasColumnName("middlename");

                    b.Property<string>("Nationality")
                        .HasColumnType("text")
                        .HasColumnName("nationality");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("ShortText")
                        .HasColumnType("text")
                        .HasColumnName("short_text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("WorkAvailabilityStatus")
                        .HasColumnType("integer")
                        .HasColumnName("work_availability_status");

                    b.HasKey("Id")
                        .HasName("pk_personal_infos");

                    b.ToTable("personal_infos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("text")
                        .HasColumnName("contact_info");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("personal_info_id");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("WorkPlace")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("work_place");

                    b.HasKey("Id")
                        .HasName("pk_references");

                    b.ToTable("references", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Skills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("personal_info_id");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("skill");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_skills");

                    b.ToTable("skills", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SupportUrls", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("PersonalInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("personal_info_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_support_urls");

                    b.ToTable("support_urls", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
