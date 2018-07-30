﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoomM.API.Persistent;

namespace RoomM.API.Migrations
{
    [DbContext(typeof(RoomMDbContext))]
    [Migration("20180729232759_AddNicknameOnProfile")]
    partial class AddNicknameOnProfile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe")
                        .HasMaxLength(255);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<bool>("NotificationViaEmail");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("ProfilesId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("ShowPhone");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfilesId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DateRead");

                    b.Property<DateTime>("DateSend");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsRead");

                    b.Property<int>("RecivedMessId");

                    b.Property<int>("SenderMessId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RecivedMessId");

                    b.HasIndex("SenderMessId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Ocupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ocupations");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsAvatar");

                    b.Property<int?>("ProfileId");

                    b.Property<int?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("RoomId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Preferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdDescription")
                        .HasMaxLength(255);

                    b.Property<string>("AdTitle")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("OcupationId");

                    b.Property<string>("PrefGender");

                    b.Property<int>("PrefMaxAge");

                    b.Property<int>("PrefMinAge");

                    b.Property<int>("RoomId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("OcupationId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("Age");

                    b.Property<string>("Comentarios");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Gender");

                    b.Property<string>("MaxRentMonth")
                        .IsRequired();

                    b.Property<DateTime>("MovingDate");

                    b.Property<int>("NickName");

                    b.Property<int>("OcupationId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OcupationId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.PropertyFeatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PropertyFeatures");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.PropertyRules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PropertyRules");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("AvailableFrom");

                    b.Property<string>("Cleanliness");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsFurnished");

                    b.Property<bool>("IsUtilityIncluded");

                    b.Property<int>("MinStayMonths");

                    b.Property<int>("NumberBathrooms");

                    b.Property<int>("NumberBedrooms");

                    b.Property<int>("NumberRoomatesAlready");

                    b.Property<string>("Pet");

                    b.Property<int>("PreferenceId");

                    b.Property<int?>("PreferenceId1");

                    b.Property<int>("PropertyId");

                    b.Property<int?>("PropertyTypeId");

                    b.Property<float>("RentPerMonth");

                    b.Property<float>("RoomSquareMeters");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RoomsToRent");

                    b.Property<string>("Smoking");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("PreferenceId1");

                    b.HasIndex("PropertyTypeId");

                    b.HasIndex("UserId1");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomFeatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("RoomFeatures");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomRoomFeatures", b =>
                {
                    b.Property<int>("RoomId");

                    b.Property<int>("RoomFeaturesId");

                    b.HasKey("RoomId", "RoomFeaturesId");

                    b.HasIndex("RoomFeaturesId");

                    b.ToTable("RoomRoomFeatures");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomsPropertyFeatures", b =>
                {
                    b.Property<int>("RoomId");

                    b.Property<int>("PropertyFeaturesId");

                    b.HasKey("RoomId", "PropertyFeaturesId");

                    b.HasIndex("PropertyFeaturesId");

                    b.ToTable("RoomsPropertyFeatures");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomsPropertyRules", b =>
                {
                    b.Property<int>("RoomId");

                    b.Property<int>("PropertyRulesId");

                    b.HasKey("RoomId", "PropertyRulesId");

                    b.HasIndex("PropertyRulesId");

                    b.ToTable("RoomsPropertyRules");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Auth.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");


                    b.ToTable("ApplicationRole");

                    b.HasDiscriminator().HasValue("ApplicationRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoomM.API.Core.Models.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Auth.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Auth.ApplicationUser", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Profile", "Profiles")
                        .WithOne("User")
                        .HasForeignKey("RoomM.API.Core.Models.Auth.ApplicationUser", "ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Message", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Profile", "RecivedMess")
                        .WithMany("MessagesRecived")
                        .HasForeignKey("RecivedMessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RoomM.API.Core.Models.Domain.Profile", "SenderMess")
                        .WithMany("MessagesSender")
                        .HasForeignKey("SenderMessId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Photo", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Profile")
                        .WithMany("Photos")
                        .HasForeignKey("ProfileId");

                    b.HasOne("RoomM.API.Core.Models.Domain.Room")
                        .WithMany("Photos")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Preferences", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Ocupation", "PrefOcuppations")
                        .WithMany()
                        .HasForeignKey("OcupationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Profile", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Ocupation", "Ocupation")
                        .WithMany()
                        .HasForeignKey("OcupationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.Room", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.Preferences", "Preference")
                        .WithMany()
                        .HasForeignKey("PreferenceId1");

                    b.HasOne("RoomM.API.Core.Models.Domain.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId");

                    b.HasOne("RoomM.API.Core.Models.Auth.ApplicationUser", "User")
                        .WithMany("Rooms")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomRoomFeatures", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.RoomFeatures", "RoomFeatures")
                        .WithMany("Room")
                        .HasForeignKey("RoomFeaturesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoomM.API.Core.Models.Domain.Room", "Room")
                        .WithMany("RoomFeatures")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomsPropertyFeatures", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.PropertyFeatures", "PropertyFeatures")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyFeaturesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoomM.API.Core.Models.Domain.Room", "Room")
                        .WithMany("PropertyFeatures")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoomM.API.Core.Models.Domain.RoomsPropertyRules", b =>
                {
                    b.HasOne("RoomM.API.Core.Models.Domain.PropertyRules", "PropertyRules")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyRulesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoomM.API.Core.Models.Domain.Room", "Room")
                        .WithMany("Rules")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
