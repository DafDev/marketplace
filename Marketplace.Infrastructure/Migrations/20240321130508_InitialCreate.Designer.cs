﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marketplace.Infrastructure.Migrations
{
    [DbContext(typeof(ClassifiedAdDbContext))]
    [Migration("20240321130508_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ComplexProperty<Dictionary<string, object>>("ApprovedBy", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.ApprovedBy#UserId", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("OwnerId", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.OwnerId#UserId", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Price", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.Price#Money", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.ComplexProperty<Dictionary<string, object>>("Currency", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.Price#Money.Currency#CurrencyDetails", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("CurrencyCode")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<int>("DecimalPlaces")
                                        .HasColumnType("integer");

                                    b2.Property<bool>("InUse")
                                        .HasColumnType("boolean");
                                });
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Text", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.Text#ClassifiedAdText", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Title", "Marketplace.Domain.Contexts.Ad.Entities.ClassifiedAd.Title#ClassifiedAdTitle", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");
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
