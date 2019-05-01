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
    [Migration("20190430151945_rmsdevicesplit")]
    partial class rmsdevicesplit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Iris.Rms.Models.Hvac", b =>
                {
                    b.Property<int>("RmsDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CurrentTemperature");

                    b.Property<string>("IpAddress");

                    b.Property<string>("Location");

                    b.Property<string>("MAC");

                    b.Property<int?>("RmsConfigRmsId");

                    b.Property<double>("SetpointTemperature");

                    b.HasKey("RmsDeviceId");

                    b.HasIndex("RmsConfigRmsId");

                    b.ToTable("Hvac");
                });

            modelBuilder.Entity("Iris.Rms.Models.Light", b =>
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

            modelBuilder.Entity("Iris.Rms.Models.RmsConfig", b =>
                {
                    b.Property<int>("RmsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAddress");

                    b.Property<string>("Location");

                    b.Property<string>("MacAddress");

                    b.Property<string>("Name");

                    b.HasKey("RmsId");

                    b.ToTable("RmsList");
                });

            modelBuilder.Entity("Iris.Rms.Models.WebHook", b =>
                {
                    b.Property<int>("WebHookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivationCommand");

                    b.Property<string>("Body");

                    b.Property<string>("HookUrl");

                    b.Property<int?>("HvacRmsDeviceId");

                    b.Property<int?>("LightRmsDeviceId");

                    b.Property<string>("Method");

                    b.HasKey("WebHookId");

                    b.HasIndex("HvacRmsDeviceId");

                    b.HasIndex("LightRmsDeviceId");

                    b.ToTable("WebHooks");
                });

            modelBuilder.Entity("Iris.Rms.Models.Hvac", b =>
                {
                    b.HasOne("Iris.Rms.Models.RmsConfig")
                        .WithMany("Hvacs")
                        .HasForeignKey("RmsConfigRmsId");
                });

            modelBuilder.Entity("Iris.Rms.Models.Light", b =>
                {
                    b.HasOne("Iris.Rms.Models.RmsConfig")
                        .WithMany("Lights")
                        .HasForeignKey("RmsConfigRmsId");
                });

            modelBuilder.Entity("Iris.Rms.Models.WebHook", b =>
                {
                    b.HasOne("Iris.Rms.Models.Hvac")
                        .WithMany("Hooks")
                        .HasForeignKey("HvacRmsDeviceId");

                    b.HasOne("Iris.Rms.Models.Light")
                        .WithMany("Hooks")
                        .HasForeignKey("LightRmsDeviceId");
                });
#pragma warning restore 612, 618
        }
    }
}
