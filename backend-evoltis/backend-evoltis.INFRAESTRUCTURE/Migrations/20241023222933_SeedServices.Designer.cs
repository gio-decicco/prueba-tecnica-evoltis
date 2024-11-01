﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_evoltis.INFRAESTRUCTURE.Context;

#nullable disable

namespace backend_evoltis.INFRAESTRUCTURE.Migrations
{
    [DbContext(typeof(EvoltisContext))]
    [Migration("20241023222933_SeedServices")]
    partial class SeedServices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend_evoltis.DOMAIN.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("backend_evoltis.DOMAIN.Entities.ClientService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ClientServices");
                });

            modelBuilder.Entity("backend_evoltis.DOMAIN.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22d4b2f5-af77-40c3-9fb2-83197b735c42"),
                            CreatedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6780),
                            Description = "Web Hosting Service",
                            ModifiedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6790),
                            Price = 1200m
                        },
                        new
                        {
                            Id = new Guid("527034dc-9327-4fc3-9236-455aad87a9ce"),
                            CreatedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6815),
                            Description = "Cloud Storage Solutions",
                            ModifiedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6816),
                            Price = 3000m
                        },
                        new
                        {
                            Id = new Guid("0d7d2fcb-4617-4611-8af4-b4608611266f"),
                            CreatedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6818),
                            Description = "Cybersecurity Monitoring",
                            ModifiedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6818),
                            Price = 4500m
                        },
                        new
                        {
                            Id = new Guid("e9843dd8-a09f-4feb-87bf-a49c93b5ab99"),
                            CreatedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6820),
                            Description = "Managed IT Support",
                            ModifiedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6820),
                            Price = 2500m
                        },
                        new
                        {
                            Id = new Guid("51d8aac0-ea05-4002-9918-f3afcefc6a97"),
                            CreatedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6821),
                            Description = "Custom Software Development",
                            ModifiedAt = new DateTime(2024, 10, 23, 19, 29, 33, 511, DateTimeKind.Local).AddTicks(6821),
                            Price = 6000m
                        });
                });

            modelBuilder.Entity("backend_evoltis.DOMAIN.Entities.ClientService", b =>
                {
                    b.HasOne("backend_evoltis.DOMAIN.Entities.Client", "Client")
                        .WithMany("Services")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_evoltis.DOMAIN.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("backend_evoltis.DOMAIN.Entities.Client", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
