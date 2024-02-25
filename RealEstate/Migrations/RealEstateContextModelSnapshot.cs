﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealEstate.Context;

#nullable disable

namespace RealEstate.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    partial class RealEstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Models.Produit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("contrat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("disponibilite")
                        .HasColumnType("boolean");

                    b.Property<byte[][]>("images")
                        .HasColumnType("bytea[]");

                    b.Property<string>("localisation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("prix")
                        .HasColumnType("integer");

                    b.Property<string>("raison")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("size")
                        .HasColumnType("integer");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("produit");
                });

            modelBuilder.Entity("RealEstate.Models.Utilisateur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("motpasse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nomutilisateur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("numtelephone")
                        .HasColumnType("text");

                    b.Property<string>("prenom")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("utilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
