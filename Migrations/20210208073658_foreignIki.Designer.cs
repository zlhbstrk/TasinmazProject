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
    [Migration("20210208073658_foreignIki")]
    partial class foreignIki
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

                    b.HasIndex("Ada", "Parsel")
                        .IsUnique();

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

                    b.Property<int>("Yetki")
                        .HasColumnType("integer");

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

                    b.HasIndex("Ad")
                        .IsUnique();

                    b.HasIndex("IlceId");

                    b.ToTable("tblMahalle");
                });

            modelBuilder.Entity("Tasinmaz.Entities.ETasinmaz", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Il", "Il")
                        .WithMany()
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Mahalle", "Mahalle")
                        .WithMany()
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
                        .WithMany()
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");
                });

            modelBuilder.Entity("Tasinmaz.Entities.Log", b =>
                {
                    b.HasOne("Tasinmaz.Entities.Durum", "Durum")
                        .WithMany()
                        .HasForeignKey("DurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.IslemTip", "IslemTip")
                        .WithMany()
                        .HasForeignKey("IslemTipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasinmaz.Entities.Kullanici", "Kullanici")
                        .WithMany()
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
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilce");
                });
#pragma warning restore 612, 618
        }
    }
}
