﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marketplace.Infrastructure.Migrations
{
    [DbContext(typeof(ClassifiedAdDbContext))]
    partial class ClassifiedAdDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd", b =>
                {
                    b.Property<Guid>("ClassifiedAdId")
                        .HasColumnType("uuid");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.ComplexProperty<Dictionary<string, object>>("OwnerId", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.OwnerId#UserId", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid");
                        });

                    b.HasKey("ClassifiedAdId");

                    b.ToTable("ClassifiedAds");
                });

            modelBuilder.Entity("Marketplace.Domain.Contexts.Ad.Entities.Picture", b =>
                {
                    b.Property<Guid>("PictureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassifiedAdId")
                        .HasColumnType("uuid");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.ComplexProperty<Dictionary<string, object>>("Size", "Marketplace.Domain.Contexts.Ad.Entities.Picture.Size#PictureSize", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Height")
                                .HasColumnType("double precision");

                            b1.Property<double>("Width")
                                .HasColumnType("double precision");
                        });

                    b.HasKey("PictureId");

                    b.HasIndex("ClassifiedAdId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd", b =>
                {
                    b.OwnsOne("Marketplace.Domain.Contexts.Ad.ValueObjects.ClassifiedAdText", "Text", b1 =>
                        {
                            b1.Property<Guid>("ClassifiedAdId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ClassifiedAdId");

                            b1.ToTable("ClassifiedAds");

                            b1.WithOwner()
                                .HasForeignKey("ClassifiedAdId");
                        });

                    b.OwnsOne("Marketplace.Domain.Contexts.Ad.ValueObjects.ClassifiedAdTitle", "Title", b1 =>
                        {
                            b1.Property<Guid>("ClassifiedAdId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ClassifiedAdId");

                            b1.ToTable("ClassifiedAds");

                            b1.WithOwner()
                                .HasForeignKey("ClassifiedAdId");
                        });

                    b.OwnsOne("Marketplace.Domain.Contexts.Ad.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ClassifiedAdId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.HasKey("ClassifiedAdId");

                            b1.ToTable("ClassifiedAds");

                            b1.WithOwner()
                                .HasForeignKey("ClassifiedAdId");

                            b1.OwnsOne("Marketplace.Domain.Contexts.Ad.ValueObjects.CurrencyDetails", "Currency", b2 =>
                                {
                                    b2.Property<Guid>("MoneyClassifiedAdId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("CurrencyCode")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<int>("DecimalPlaces")
                                        .HasColumnType("integer");

                                    b2.Property<bool>("InUse")
                                        .HasColumnType("boolean");

                                    b2.HasKey("MoneyClassifiedAdId");

                                    b2.ToTable("ClassifiedAds");

                                    b2.WithOwner()
                                        .HasForeignKey("MoneyClassifiedAdId");
                                });

                            b1.Navigation("Currency")
                                .IsRequired();
                        });

                    b.OwnsOne("Marketplace.Domain.Contexts.Ad.ValueObjects.UserId", "ApprovedBy", b1 =>
                        {
                            b1.Property<Guid>("ClassifiedAdId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid");

                            b1.HasKey("ClassifiedAdId");

                            b1.ToTable("ClassifiedAds");

                            b1.WithOwner()
                                .HasForeignKey("ClassifiedAdId");
                        });

                    b.Navigation("ApprovedBy");

                    b.Navigation("Price");

                    b.Navigation("Text");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Marketplace.Domain.Contexts.Ad.Entities.Picture", b =>
                {
                    b.HasOne("Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd", null)
                        .WithMany("Pictures")
                        .HasForeignKey("ClassifiedAdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd", b =>
                {
                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
