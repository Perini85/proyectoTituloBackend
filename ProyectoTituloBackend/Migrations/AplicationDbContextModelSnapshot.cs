﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoTituloBackend.Persistence.Context;

namespace ProyectoTituloBackend.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDoc")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("TipoDocumentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Documento", b =>
                {
                    b.HasOne("ProyectoTituloBackend.Domain.Models.Clientes", "Clientes")
                        .WithMany("ListDocumentos")
                        .HasForeignKey("ClientesId");

                    b.HasOne("ProyectoTituloBackend.Domain.Models.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTituloBackend.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoTituloBackend.Domain.Models.Producto", b =>
                {
                    b.HasOne("ProyectoTituloBackend.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}