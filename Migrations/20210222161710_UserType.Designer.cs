﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerceAssessment.Data;

namespace ecommerceassessment.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210222161710_UserType")]
    partial class UserType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCommerceAssessment.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPrimary")
                        .HasColumnType("bit");

                    b.Property<int>("postalCode")
                        .HasColumnType("int");

                    b.Property<int>("postalCodeExt")
                        .HasColumnType("int");

                    b.Property<string>("street1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("typeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.UserType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accessLevel")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.Address", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.User", "user")
                        .WithMany("addresses")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.HasOne("eCommerceAssessment.Models.UserType", "type")
                        .WithMany("users")
                        .HasForeignKey("typeid");

                    b.Navigation("type");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.User", b =>
                {
                    b.Navigation("addresses");
                });

            modelBuilder.Entity("eCommerceAssessment.Models.UserType", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
