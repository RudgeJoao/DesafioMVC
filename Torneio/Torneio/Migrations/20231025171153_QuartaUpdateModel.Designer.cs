﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Torneio.Data;

#nullable disable

namespace Torneio.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20231025171153_QuartaUpdateModel")]
    partial class QuartaUpdateModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RM87725")
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Torneio.Models.Lutador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtesMarciais")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Derrotas")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Idade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("TotalLutas")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Vitorias")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Lutadores", "RM87725");
                });

            modelBuilder.Entity("Torneio.Models.ResultadoTorneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Data")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<double?>("TaxaDeVitorias")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("Vencedor")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("ResultadoTorneios", "RM87725");
                });
#pragma warning restore 612, 618
        }
    }
}
