﻿// <auto-generated />
using System;
using A_Team.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20221101104055_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("A_Team.Core.Model.AccountModel.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Type").HasValue("Account");
                });

            modelBuilder.Entity("A_Team.Core.Model.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageField")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Payment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("A_Team.Core.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SocialSecurityNumber")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("A_Team.Core.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("FromAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Receipt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("A_Team.Core.Model.AccountModel.CurrentAccount", b =>
                {
                    b.HasBaseType("A_Team.Core.Model.AccountModel.Account");

                    b.Property<int>("Interest")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Interest");

                    b.Property<int>("WithdrawLimit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("INTEGER")
                        .HasColumnName("WithdrawLimit");

                    b.HasDiscriminator().HasValue("CurrentAccount");
                });

            modelBuilder.Entity("A_Team.Core.Model.AccountModel.SavingAccount", b =>
                {
                    b.HasBaseType("A_Team.Core.Model.AccountModel.Account");

                    b.Property<int>("Interest")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Interest");

                    b.Property<int>("WithdrawLimit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("INTEGER")
                        .HasColumnName("WithdrawLimit");

                    b.HasDiscriminator().HasValue("SavingsAccount");
                });
#pragma warning restore 612, 618
        }
    }
}