﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.DomainModel;

namespace MyAPI.DomainModel.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181015203334_FixFKPermissionGroup")]
    partial class FixFKPermissionGroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("txt_name");

                    b.HasKey("Id");

                    b.ToTable("t_permission_group");
                });

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.LinkGroupUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("IdPermissionGroup")
                        .HasColumnName("id_permission_group");

                    b.Property<long>("IdUser")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("IdPermissionGroup");

                    b.HasIndex("IdUser");

                    b.ToTable("t_link_group_user");
                });

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.LinkPermissionGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("IdPermission")
                        .HasColumnName("id_permission");

                    b.Property<long>("IdPermissionGroup")
                        .HasColumnName("id_permission_group");

                    b.HasKey("Id");

                    b.HasIndex("IdPermission");

                    b.HasIndex("IdPermissionGroup");

                    b.ToTable("t_link_perm_group");
                });

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Level")
                        .HasColumnName("cd_level");

                    b.Property<int>("Type")
                        .HasColumnName("num_type");

                    b.HasKey("Id");

                    b.ToTable("t_permission");
                });

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

            modelBuilder.Entity("MyAPI.DomainModel.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AccessKey")
                        .HasColumnName("txt_access_key");

                    b.Property<string>("Name")
                        .HasColumnName("txt_name");

                    b.Property<string>("Username")
                        .HasColumnName("txt_username");

                    b.HasKey("Id");

                    b.ToTable("t_user");
                });

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.LinkGroupUser", b =>
                {
                    b.HasOne("MyAPI.DomainModel.Authorization.Group", "Group")
                        .WithMany()
                        .HasForeignKey("IdPermissionGroup")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyAPI.DomainModel.Entities.User", "User")
                        .WithMany("GroupUserList")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyAPI.DomainModel.Authorization.LinkPermissionGroup", b =>
                {
                    b.HasOne("MyAPI.DomainModel.Authorization.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyAPI.DomainModel.Authorization.Group", "Group")
                        .WithMany()
                        .HasForeignKey("IdPermissionGroup")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
