﻿// <auto-generated />
using System;
using Iris.Rms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Iris.Rms.Data.Migrations
{
    [DbContext(typeof(RmsDbContext))]
    [Migration("20190429132623_webhooks-update")]
    partial class webhooksupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Iris.Rms.Models.RmsConfig", b =>
                {
                    b.Property<int>("RmsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("RmsId");

                    b.ToTable("RmsList");
                });

            modelBuilder.Entity("Iris.Rms.Models.RmsDevice", b =>
                {
                    b.Property<int>("RmsDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentStatus");

                    b.Property<string>("IpAddress");

                    b.Property<string>("Location");

                    b.Property<string>("MAC");

                    b.Property<int?>("RmsConfigRmsId");

                    b.Property<int>("Type");

                    b.HasKey("RmsDeviceId");

                    b.HasIndex("RmsConfigRmsId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Iris.Rms.Models.WebHook", b =>
                {
                    b.Property<int>("WebHookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivationCommand");

                    b.Property<string>("Body");

                    b.Property<string>("HookUrl");

                    b.Property<string>("Method");

                    b.Property<int?>("RmsDeviceId");

                    b.HasKey("WebHookId");

                    b.HasIndex("RmsDeviceId");

                    b.ToTable("WebHooks");
                });

            modelBuilder.Entity("Iris.Rms.Models.RmsDevice", b =>
                {
                    b.HasOne("Iris.Rms.Models.RmsConfig")
                        .WithMany("Devices")
                        .HasForeignKey("RmsConfigRmsId");
                });

            modelBuilder.Entity("Iris.Rms.Models.WebHook", b =>
                {
                    b.HasOne("Iris.Rms.Models.RmsDevice")
                        .WithMany("Hooks")
                        .HasForeignKey("RmsDeviceId");
                });
#pragma warning restore 612, 618
        }
    }
}
