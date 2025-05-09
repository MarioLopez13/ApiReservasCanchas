﻿// <auto-generated />
using System;
using ApiReservasCanchas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiReservasCanchas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ApiReservasCanchas.Models.Cancha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Canchas");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.HistorialOcupacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CanchaId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoOcupacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.ToTable("HistorialesOcupacion");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CanchaId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponible")
                        .HasColumnType("tinyint(1)");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Promocion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activa")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CanchaId")
                        .HasColumnType("int");

                    b.Property<int>("Descuento")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time(6)");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.ToTable("Promociones");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CanchaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time(6)");

                    b.Property<decimal>("PrecioFinal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.HistorialOcupacion", b =>
                {
                    b.HasOne("ApiReservasCanchas.Models.Cancha", "Cancha")
                        .WithMany("HistorialOcupaciones")
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Horario", b =>
                {
                    b.HasOne("ApiReservasCanchas.Models.Cancha", "Cancha")
                        .WithMany("Horarios")
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Promocion", b =>
                {
                    b.HasOne("ApiReservasCanchas.Models.Cancha", "Cancha")
                        .WithMany("Promociones")
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Reserva", b =>
                {
                    b.HasOne("ApiReservasCanchas.Models.Cancha", "Cancha")
                        .WithMany("Reservas")
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiReservasCanchas.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Cancha", b =>
                {
                    b.Navigation("HistorialOcupaciones");

                    b.Navigation("Horarios");

                    b.Navigation("Promociones");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ApiReservasCanchas.Models.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
