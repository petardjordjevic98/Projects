﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProbCut.Migrations
{
    [DbContext(typeof(SalonContext))]
    [Migration("20200508130014_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProbCut.Models.Frizer", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("brojOcena")
                        .HasColumnType("int");

                    b.Property<int>("brojRealizovanihTermina")
                        .HasColumnType("int");

                    b.Property<string>("brojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pol")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("polKojiSisa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<float>("prosecnaOcena")
                        .HasColumnType("real");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("Frizeri");
                });

            modelBuilder.Entity("ProbCut.Models.Komentar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("autorid")
                        .HasColumnType("int");

                    b.Property<int>("frizerid")
                        .HasColumnType("int");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("autorid");

                    b.HasIndex("frizerid");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("ProbCut.Models.Musterija", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("brojRealizovanihTermina")
                        .HasColumnType("int");

                    b.Property<string>("brojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pol")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("terminid")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.HasIndex("terminid");

                    b.ToTable("Musterije");
                });

            modelBuilder.Entity("ProbCut.Models.Poruka", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idPosiljaoca")
                        .HasColumnType("int");

                    b.Property<int>("idPrimaoca")
                        .HasColumnType("int");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("ProbCut.Models.Termin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("frizerid")
                        .HasColumnType("int");

                    b.Property<int>("trajanjeUMinutima")
                        .HasColumnType("int");

                    b.Property<DateTime>("vreme")
                        .HasColumnType("datetime2");

                    b.Property<string>("vrstaUsluge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("frizerid");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("ProbCut.Models.Vlasnik", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("brojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pol")
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("poslednjiPutUlogovan")
                        .HasColumnType("datetime2");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("Vlasnici");
                });

            modelBuilder.Entity("ProbCut.Models.Komentar", b =>
                {
                    b.HasOne("ProbCut.Models.Musterija", "autor")
                        .WithMany()
                        .HasForeignKey("autorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProbCut.Models.Frizer", "frizer")
                        .WithMany("komentari")
                        .HasForeignKey("frizerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProbCut.Models.Musterija", b =>
                {
                    b.HasOne("ProbCut.Models.Termin", "termin")
                        .WithMany()
                        .HasForeignKey("terminid");
                });

            modelBuilder.Entity("ProbCut.Models.Termin", b =>
                {
                    b.HasOne("ProbCut.Models.Frizer", "frizer")
                        .WithMany("termini")
                        .HasForeignKey("frizerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
