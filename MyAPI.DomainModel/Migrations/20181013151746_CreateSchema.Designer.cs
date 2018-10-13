﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.DomainModel;

namespace MyAPI.DomainModel.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181013151746_CreateSchema")]
    partial class CreateSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyAPI.DomainModel.Entities.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("IsComplete")
                        .HasColumnName("fl_complete");

                    b.Property<string>("Name")
                        .HasColumnName("txt_name");

                    b.HasKey("Id");

                    b.ToTable("t_item");
                });
#pragma warning restore 612, 618
        }
    }
}
