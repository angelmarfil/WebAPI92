﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI92.Context;

#nullable disable

namespace WebAPI92.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Autor", b =>
                {
                    b.Property<int>("PkAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkAutor"), 1L, 1);

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkAutor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Domain.Entities.Libro", b =>
                {
                    b.Property<int>("PkLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkLibro"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editorial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FkAutor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkLibro");

                    b.HasIndex("FkAutor");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRol"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Nombre = "sa"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"), 1L, 1);

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1,
                            FkRol = 1,
                            Nombre = "Angel",
                            Password = "password",
                            User = "angelmarfil"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Libro", b =>
                {
                    b.HasOne("Domain.Entities.Autor", "Autores")
                        .WithMany()
                        .HasForeignKey("FkAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autores");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
