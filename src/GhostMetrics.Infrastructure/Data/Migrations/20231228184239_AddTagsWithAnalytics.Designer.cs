﻿// <auto-generated />
using System;
using GhostMetrics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GhostMetrics.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231228184239_AddTagsWithAnalytics")]
    partial class AddTagsWithAnalytics
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.AuthorAnalytics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PageViews")
                        .HasColumnType("integer");

                    b.Property<int>("ReturningVisitors")
                        .HasColumnType("integer");

                    b.Property<int>("TotalTime")
                        .HasColumnType("integer");

                    b.Property<int>("Uniques")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("AuthorAnalytics");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.PostAnalytics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PageViews")
                        .HasColumnType("integer");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<int>("ReturningVisitors")
                        .HasColumnType("integer");

                    b.Property<int>("TotalTime")
                        .HasColumnType("integer");

                    b.Property<int>("Uniques")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostAnalytics");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.TagAnalytics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PageViews")
                        .HasColumnType("integer");

                    b.Property<int>("ReturningVisitors")
                        .HasColumnType("integer");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<int>("TotalTime")
                        .HasColumnType("integer");

                    b.Property<int>("Uniques")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("TagAnalytics");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("GhostAuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.IntegrationDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AdminApiKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApiUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContentApiKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("GhostSiteId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SiteIntegrationDetails");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Excerpt")
                        .HasColumnType("text");

                    b.Property<bool>("Featured")
                        .HasColumnType("boolean");

                    b.Property<string>("FeaturedImagePath")
                        .HasColumnType("text");

                    b.Property<Guid>("GhostPostId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ReadingTime")
                        .HasColumnType("integer");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<string>("Visibility")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.PostAuthor", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("PostId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("PostAuthors");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.PostTag", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Indexed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastIndexed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("ListId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Paused")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.SiteList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("SiteLists");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FeaturedImage")
                        .HasColumnType("text");

                    b.Property<string>("GhostTagId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.SEO.PostSeo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("text");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("text");

                    b.Property<string>("OgDescription")
                        .HasColumnType("text");

                    b.Property<string>("OgImage")
                        .HasColumnType("text");

                    b.Property<string>("OgTitle")
                        .HasColumnType("text");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<string>("XDescription")
                        .HasColumnType("text");

                    b.Property<string>("XImage")
                        .HasColumnType("text");

                    b.Property<string>("XTitle")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("PostSeo");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.SEO.TagSeo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TagId")
                        .IsUnique();

                    b.ToTable("TagSeo");
                });

            modelBuilder.Entity("GhostMetrics.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.AuthorAnalytics", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Author", "Author")
                        .WithOne("Analytics")
                        .HasForeignKey("GhostMetrics.Core.Domain.Entities.Analytics.AuthorAnalytics", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.PostAnalytics", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Post", "Post")
                        .WithMany("Analytics")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Analytics.TagAnalytics", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Tag", "Tag")
                        .WithMany("Analytics")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.IntegrationDetail", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Site", "Site")
                        .WithOne("IntegrationDetails")
                        .HasForeignKey("GhostMetrics.Core.Domain.Entities.Ghost.IntegrationDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Post", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Site", "Site")
                        .WithMany("Posts")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.PostAuthor", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Author", "Author")
                        .WithMany("PostAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Post", "Post")
                        .WithMany("PostAuthors")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.PostTag", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Site", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.SiteList", "List")
                        .WithMany("GhostSites")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.SiteList", b =>
                {
                    b.OwnsOne("GhostMetrics.Core.Domain.ValueObjects.Color", "Color", b1 =>
                        {
                            b1.Property<Guid>("SiteListId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SiteListId");

                            b1.ToTable("SiteLists");

                            b1.WithOwner()
                                .HasForeignKey("SiteListId");
                        });

                    b.Navigation("Color")
                        .IsRequired();
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.SEO.PostSeo", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Post", "Post")
                        .WithOne("Seo")
                        .HasForeignKey("GhostMetrics.Core.Domain.Entities.SEO.PostSeo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.SEO.TagSeo", b =>
                {
                    b.HasOne("GhostMetrics.Core.Domain.Entities.Ghost.Tag", "Tag")
                        .WithOne("Seo")
                        .HasForeignKey("GhostMetrics.Core.Domain.Entities.SEO.TagSeo", "TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GhostMetrics.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GhostMetrics.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GhostMetrics.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GhostMetrics.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Author", b =>
                {
                    b.Navigation("Analytics");

                    b.Navigation("PostAuthors");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Post", b =>
                {
                    b.Navigation("Analytics");

                    b.Navigation("PostAuthors");

                    b.Navigation("PostTags");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Site", b =>
                {
                    b.Navigation("IntegrationDetails")
                        .IsRequired();

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.SiteList", b =>
                {
                    b.Navigation("GhostSites");
                });

            modelBuilder.Entity("GhostMetrics.Core.Domain.Entities.Ghost.Tag", b =>
                {
                    b.Navigation("Analytics");

                    b.Navigation("PostTags");

                    b.Navigation("Seo");
                });
#pragma warning restore 612, 618
        }
    }
}
