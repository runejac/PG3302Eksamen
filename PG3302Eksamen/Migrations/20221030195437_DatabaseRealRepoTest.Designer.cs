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
    [Migration("20221030195437_DatabaseRealRepoTest")]
    partial class DatabaseRealRepoTest
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

                    b.HasIndex("OwnerId");

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

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("A_Team.Core.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Receipt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

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

            modelBuilder.Entity("A_Team.Core.Model.AccountModel.Account", b =>
                {
                    b.HasOne("A_Team.Core.Model.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("A_Team.Core.Model.Transaction", b =>
                {
                    b.HasOne("A_Team.Core.Model.AccountModel.Account", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
