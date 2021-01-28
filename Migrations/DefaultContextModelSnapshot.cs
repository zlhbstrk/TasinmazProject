﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasinmaz.Entities;

namespace Tasinmaz.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Tasinmaz.Entities.Durum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("ID");

                    b.ToTable("tblDurum");
                });

            modelBuilder.Entity("Tasinmaz.Entities.ETasinmaz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Ada")
                        .HasColumnType("integer");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("IlID")
                        .HasColumnType("integer");

                    b.Property<int>("IlceID")
                        .HasColumnType("integer");

                    b.Property<int>("MahalleID")
                        .HasColumnType("integer");

                    b.Property<string>("Nitelik")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Parsel")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IlID");

                    b.HasIndex("IlceID");

                    b.HasIndex("MahalleID");

                    b.ToTable("tblTasinmaz");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Il", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Plaka")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("tblIl");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Ilce", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("IlID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IlID");

                    b.ToTable("tblIlce");
                });

            modelBuilder.Entity("Tasinmaz.Entities.IslemTip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("ID");

                    b.ToTable("tblIslemTip");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Soyad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<byte>("Yetki")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("tblKullanici");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Log", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("DurumID")
                        .HasColumnType("integer");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("IslemTipID")
                        .HasColumnType("integer");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("DurumID");

                    b.HasIndex("IslemTipID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("tblLog");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Mahalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("IlceID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IlceID");

                    b.ToTable("tblMahalle");
                });

            modelBuilder.Entity("Tasinmaz.Entities.ETasinmaz", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Il", "Il")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("IlID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Ilce", "Ilce")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("IlceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Mahalle", "Mahalle")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("MahalleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");

                    b.Navigation("Ilce");

                    b.Navigation("Mahalle");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Ilce", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Il", "Il")
                        .WithMany("tblIlce")
                        .HasForeignKey("IlID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Log", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Durum", "Durum")
                        .WithMany("tblLog")
                        .HasForeignKey("DurumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.IslemTip", "IslemTip")
                        .WithMany("tblLog")
                        .HasForeignKey("IslemTipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Kullanici", "Kullanici")
                        .WithMany("tblLog")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Durum");

                    b.Navigation("IslemTip");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Mahalle", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Ilce", "Ilce")
                        .WithMany("tblMahalle")
                        .HasForeignKey("IlceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilce");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Durum", b =>
                {
                    b.Navigation("tblLog");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Il", b =>
                {
                    b.Navigation("tblIlce");

                    b.Navigation("tblTasinmaz");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Ilce", b =>
                {
                    b.Navigation("tblMahalle");

                    b.Navigation("tblTasinmaz");
                });

            modelBuilder.Entity("Tasinmaz.Entities.IslemTip", b =>
                {
                    b.Navigation("tblLog");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Kullanici", b =>
                {
                    b.Navigation("tblLog");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Mahalle", b =>
                {
                    b.Navigation("tblTasinmaz");
                });
#pragma warning restore 612, 618
        }
    }
}
