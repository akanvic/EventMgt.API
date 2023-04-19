﻿// <auto-generated />
using System;
using EventMgt.Repo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventMgt.Repo.Migrations
{
    [DbContext(typeof(EventMgtContext))]
    [Migration("20230419210927_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.15");

            modelBuilder.Entity("EventMgt.Core.Models.ApplicationUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("EventMgt.Core.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventCreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventDescription")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.HasIndex("EventCreatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventMgt.Core.Models.EventParticipant", b =>
                {
                    b.Property<int>("EventParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EventParticipantStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventParticipantId");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("EventMgt.Core.Models.ParticipantInvitation", b =>
                {
                    b.Property<int>("ParticipantInvitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventCreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EventInvitationStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParticipantInvitationId");

                    b.HasIndex("EventCreatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("ParticipantInvitations");
                });

            modelBuilder.Entity("EventMgt.Core.Models.Event", b =>
                {
                    b.HasOne("EventMgt.Core.Models.ApplicationUser", "EventCreator")
                        .WithMany()
                        .HasForeignKey("EventCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventCreator");
                });

            modelBuilder.Entity("EventMgt.Core.Models.EventParticipant", b =>
                {
                    b.HasOne("EventMgt.Core.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMgt.Core.Models.ApplicationUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("EventMgt.Core.Models.ParticipantInvitation", b =>
                {
                    b.HasOne("EventMgt.Core.Models.ApplicationUser", "EventCreator")
                        .WithMany()
                        .HasForeignKey("EventCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMgt.Core.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMgt.Core.Models.ApplicationUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("EventCreator");

                    b.Navigation("Participant");
                });
#pragma warning restore 612, 618
        }
    }
}
