﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagamentoAPI.Context;

#nullable disable

namespace PagamentoAPI.Migrations
{
    [DbContext(typeof(PagamentoContext))]
    [Migration("20231222020931_Boletos1")]
    partial class Boletos1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PagamentoAPI.Models.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("CodigoDoBanco")
                        .HasColumnType("longtext")
                        .HasColumnName("Codigo_Banco");

                    b.Property<string>("NomeDoBanco")
                        .HasColumnType("longtext")
                        .HasColumnName("Nome_Banco");

                    b.Property<decimal>("PercentualDeJuros")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("Percentual_Juros");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("PagamentoAPI.Models.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("CPFCNPJBeneficiario")
                        .HasColumnType("longtext")
                        .HasColumnName("CPF_CNPJ_Beneficiario");

                    b.Property<string>("CPFCNPJPagador")
                        .HasColumnType("longtext")
                        .HasColumnName("CPF_CNPJ_Pagador");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Data_vencimento");

                    b.Property<string>("NomeBeneficiario")
                        .HasColumnType("longtext")
                        .HasColumnName("Nome_Beneficiario");

                    b.Property<string>("NomePagador")
                        .HasColumnType("longtext")
                        .HasColumnName("Nome_Pagador");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext")
                        .HasColumnName("Observacao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("PagamentoAPI.Models.Boleto", b =>
                {
                    b.HasOne("PagamentoAPI.Models.Banco", "Banco")
                        .WithMany("Boletos")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("PagamentoAPI.Models.Banco", b =>
                {
                    b.Navigation("Boletos");
                });
#pragma warning restore 612, 618
        }
    }
}
