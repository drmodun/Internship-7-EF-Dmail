﻿// <auto-generated />
using System;
using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dmail.Data.Migrations
{
    [DbContext(typeof(DmailContext))]
    [Migration("20230105001814_Remove-Events-and-EventsUsers")]
    partial class RemoveEventsandEventsUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dmail.Data.Entities.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsEvent")
                        .HasColumnType("boolean");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.MessagesReceivers", b =>
                {
                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("MessageId")
                        .HasColumnType("integer");

                    b.Property<bool>("Accepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.HasKey("ReceiverId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("MessagesReceivers");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Spam", b =>
                {
                    b.Property<int>("BlockerId")
                        .HasColumnType("integer");

                    b.Property<int>("Blocked")
                        .HasColumnType("integer");

                    b.HasKey("BlockerId", "Blocked");

                    b.ToTable("Spam");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Jan@gmail.com",
                            _password = "janv2"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bartol@dump.hr",
                            _password = "bartolV10"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Message", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.User", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.MessagesReceivers", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Message", "Message")
                        .WithMany("MessagesReceivers")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.User", "Receiver")
                        .WithMany("MessagesReceivers")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Spam", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.User", "Blocker")
                        .WithMany("Spams")
                        .HasForeignKey("BlockerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blocker");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Message", b =>
                {
                    b.Navigation("MessagesReceivers");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("MessagesReceivers");

                    b.Navigation("Spams");
                });
#pragma warning restore 612, 618
        }
    }
}