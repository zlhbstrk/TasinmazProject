﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasinmaz.Entities;

namespace Tasinmaz.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20210204204857_unique3")]
    partial class unique3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Tasinmaz.Entities.Durum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("tblDurum");
                });

            modelBuilder.Entity("Tasinmaz.Entities.ETasinmaz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Ada")
                        .HasColumnType("integer");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("IlId")
                        .HasColumnType("integer");

                    b.Property<int>("IlceId")
                        .HasColumnType("integer");

                    b.Property<int>("MahalleId")
                        .HasColumnType("integer");

                    b.Property<string>("Nitelik")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Parsel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IlId");

                    b.HasIndex("IlceId");

                    b.HasIndex("MahalleId");

                    b.ToTable("tblTasinmaz");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Il", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Plaka")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Ad")
                        .IsUnique();

                    b.ToTable("tblIl");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Ilce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("IlId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Ad")
                        .IsUnique();

                    b.HasIndex("IlId");

                    b.ToTable("tblIlce");
                });

            modelBuilder.Entity("Tasinmaz.Entities.IslemTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("tblIslemTip");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("tblKullanici");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("DurumId")
                        .HasColumnType("integer");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("IslemTipId")
                        .HasColumnType("integer");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DurumId");

                    b.HasIndex("IslemTipId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("tblLog");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Mahalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("IlceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IlceId");

                    b.ToTable("tblMahalle");
                });

            modelBuilder.Entity("Tasinmaz.Entities.ETasinmaz", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Il", "Il")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Ilce", "Ilce")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Mahalle", "Mahalle")
                        .WithMany("tblTasinmaz")
                        .HasForeignKey("MahalleId")
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
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Log", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Durum", "Durum")
                        .WithMany("tblLog")
                        .HasForeignKey("DurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.IslemTip", "IslemTip")
                        .WithMany("tblLog")
                        .HasForeignKey("IslemTipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Kullanici", "Kullanici")
                        .WithMany("tblLog")
                        .HasForeignKey("KullaniciId")
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
                        .HasForeignKey("IlceId")
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
