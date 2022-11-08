﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PG3302Eksamen.Repositories;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20221107212639_new11111")]
    partial class new11111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("PG3302Eksamen.Model.AccountModel.Account", b =>
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

            modelBuilder.Entity("PG3302Eksamen.Model.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageField")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("PG3302Eksamen.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
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

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("SocialSecurityNumber")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PG3302Eksamen.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("FromAccount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToAccount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FromAccount")
                        .IsUnique();

                    b.HasIndex("ToAccount")
                        .IsUnique();

                    b.ToTable("Transactions");

                    b.HasDiscriminator<string>("Type").HasValue("Transaction");
                });

            modelBuilder.Entity("PG3302Eksamen.Model.AccountModel.CurrentAccount", b =>
                {
                    b.HasBaseType("PG3302Eksamen.Model.AccountModel.Account");

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

            modelBuilder.Entity("PG3302Eksamen.Model.AccountModel.SavingAccount", b =>
                {
                    b.HasBaseType("PG3302Eksamen.Model.AccountModel.Account");

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

            modelBuilder.Entity("PG3302Eksamen.Model.Deposit", b =>
                {
                    b.HasBaseType("PG3302Eksamen.Model.Transaction");

                    b.HasDiscriminator().HasValue("Deposit");
                });

            modelBuilder.Entity("PG3302Eksamen.Model.Payment", b =>
                {
                    b.HasBaseType("PG3302Eksamen.Model.Transaction");

                    b.Property<int>("Receipt")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Payment");
                });

            modelBuilder.Entity("PG3302Eksamen.Model.Transfer", b =>
                {
                    b.HasBaseType("PG3302Eksamen.Model.Transaction");

                    b.Property<int>("Receipt")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Transfer_Receipt");

                    b.HasDiscriminator().HasValue("Transfer");
                });
#pragma warning restore 612, 618
        }
    }
}
