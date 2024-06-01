﻿// <auto-generated />
using System;
using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaDesafios.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601123953_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndEvent")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("SendEmail")
                        .HasColumnType("bit");

                    b.Property<int>("SituationEvent")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartEvent")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("UserId");

                    b.ToTable("Calendars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Reunião para planejamento do próximo trimestre",
                            EndEvent = new DateTime(2024, 6, 3, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            IdUser = 1,
                            SendEmail = true,
                            SituationEvent = 1,
                            StartEvent = new DateTime(2024, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 1,
                            Title = "Reunião de Planejamento"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Almoço com cliente para discutir detalhes do projeto",
                            EndEvent = new DateTime(2024, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            IdUser = 1,
                            SendEmail = true,
                            SituationEvent = 1,
                            StartEvent = new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 1,
                            Title = "Almoço com Cliente"
                        });
                });

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.Phonebook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("UserId");

                    b.ToTable("Phonebooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "joao@example.com",
                            IdUser = 1,
                            Name = "João",
                            Phone = "(11) 1234-5678",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "maria@example.com",
                            IdUser = 1,
                            Name = "Maria",
                            Phone = "(11) 9876-5432",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "pedro@example.com",
                            IdUser = 1,
                            Name = "Pedro",
                            Phone = "(11) 4567-8901",
                            Status = 1
                        });
                });

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 1, 9, 39, 53, 483, DateTimeKind.Local).AddTicks(8905),
                            Email = "admin@blue.com",
                            Name = "Admin",
                            Password = "yourpassword",
                            Status = 1,
                            Updated = new DateTime(2024, 6, 1, 9, 39, 53, 483, DateTimeKind.Local).AddTicks(8916)
                        });
                });

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.Calendar", b =>
                {
                    b.HasOne("AgendaDesafios.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaDesafios.Domain.Entities.User", null)
                        .WithMany("Calendar")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.Phonebook", b =>
                {
                    b.HasOne("AgendaDesafios.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaDesafios.Domain.Entities.User", null)
                        .WithMany("Phonebook")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgendaDesafios.Domain.Entities.User", b =>
                {
                    b.Navigation("Calendar");

                    b.Navigation("Phonebook");
                });
#pragma warning restore 612, 618
        }
    }
}
