﻿// <auto-generated />
using krakenTradeMiner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace krakenTradeMiner.Migrations
{
    [DbContext(typeof(KrakenTradeMinerContext))]
    partial class KrakenTradeMinerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("krakenTradeMiner.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direction");

                    b.Property<long>("LastTradeId");

                    b.Property<string>("Miscellaneous");

                    b.Property<string>("Pair");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Type");

                    b.Property<decimal>("UnixTime");

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.ToTable("trades");
                });
#pragma warning restore 612, 618
        }
    }
}
