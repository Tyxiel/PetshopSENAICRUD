﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetshopSENAICRUD.Models;

#nullable disable

namespace PetshopSENAICRUD.Migrations
{
    [DbContext(typeof(PetshopSENAIDBContext))]
    [Migration("20250429144956_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PetshopSENAICRUD.Models.Animal", b =>
                {
                    b.Property<int>("IdAnimal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAnimal"), 1L, 1);

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("especie");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<byte>("Idade")
                        .HasColumnType("tinyint")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("raca");

                    b.HasKey("IdAnimal")
                        .HasName("PK_Animal");

                    b.HasIndex("IdCliente");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("endereco");

                    b.Property<int?>("IdPreferencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("nome");

                    b.Property<int?>("PreferenciaDeNotificacaoIdPreferencia")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("telefone");

                    b.HasKey("IdCliente")
                        .HasName("PK_Cliente");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdPreferencia");

                    b.HasIndex("PreferenciaDeNotificacaoIdPreferencia");

                    b.HasIndex("Telefone")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Consultum", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<int?>("IdAnimal")
                        .HasColumnType("int");

                    b.Property<int?>("IdStatus")
                        .HasColumnType("int");

                    b.Property<int?>("IdVeterinario")
                        .HasColumnType("int");

                    b.HasKey("IdConsulta")
                        .HasName("PK_Consulta");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdVeterinario");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.CopiaDeSeguranca", b =>
                {
                    b.Property<int>("IdBackup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBackup"), 1L, 1);

                    b.Property<DateTime>("DataExecucao")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraExecucao")
                        .HasColumnType("time");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StatusIntegridade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TamanhoBackup")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("TipoBackup")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdBackup")
                        .HasName("PK_CopiaDeSeguranca");

                    b.ToTable("CopiaDeSeguranca", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Feedback", b =>
                {
                    b.Property<int>("IdFeedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFeedback"), 1L, 1);

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoFeedback")
                        .HasColumnType("int");

                    b.Property<byte>("Tipo")
                        .HasColumnType("tinyint")
                        .HasColumnName("tipo");

                    b.HasKey("IdFeedback")
                        .HasName("PK_Feedback");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdTipoFeedback");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.FormaDePagamento", b =>
                {
                    b.Property<int>("IdFormaDePagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormaDePagamento"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdFormaDePagamento")
                        .HasName("PK_FormaDePagamento");

                    b.ToTable("FormaDePagamento", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Notificacao", b =>
                {
                    b.Property<int>("IdNotificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacao"), 1L, 1);

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("date")
                        .HasColumnName("data_envio");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tipo");

                    b.HasKey("IdNotificacao")
                        .HasName("PK_Notificacao");

                    b.HasIndex("IdCliente");

                    b.ToTable("Notificacao", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Pagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPagamento"), 1L, 1);

                    b.Property<int?>("IdFormaDePagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("valor");

                    b.HasKey("IdPagamento")
                        .HasName("PK_Pagamento");

                    b.HasIndex("IdFormaDePagamento");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.PreferenciaDeNotificacao", b =>
                {
                    b.Property<int>("IdPreferencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPreferencia"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descricao");

                    b.HasKey("IdPreferencia")
                        .HasName("PK_PreferenciaDeNotificacao");

                    b.ToTable("PreferenciaDeNotificacao", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Receitum", b =>
                {
                    b.Property<int>("IdReceita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReceita"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("descricao");

                    b.Property<int?>("IdConsulta")
                        .HasColumnType("int");

                    b.HasKey("IdReceita")
                        .HasName("PK_Receita");

                    b.HasIndex("IdConsulta");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.StatusConsultum", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descricao");

                    b.HasKey("IdStatus")
                        .HasName("PK_StatusConsulta");

                    b.ToTable("StatusConsulta");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.TipoFeedback", b =>
                {
                    b.Property<int>("IdTipoFeedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoFeedback"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("descricao");

                    b.HasKey("IdTipoFeedback")
                        .HasName("PK_TipoFeedback");

                    b.ToTable("TipoFeedback", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Veterinario", b =>
                {
                    b.Property<int>("IdVeterinario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVeterinario"), 1L, 1);

                    b.Property<string>("Crmv")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("CRMV");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("IdVeterinario")
                        .HasName("PK_Veterinario");

                    b.ToTable("Veterinario", (string)null);
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Animal", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Animals")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Animal_IdCliente");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Cliente", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.PreferenciaDeNotificacao", "IdPreferenciaNavigation")
                        .WithMany()
                        .HasForeignKey("IdPreferencia")
                        .HasConstraintName("FK_Cliente_PreferenciaDeNotificacao");

                    b.HasOne("PetshopSENAICRUD.Models.PreferenciaDeNotificacao", null)
                        .WithMany("IdClientes")
                        .HasForeignKey("PreferenciaDeNotificacaoIdPreferencia");

                    b.Navigation("IdPreferenciaNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Consultum", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.Animal", "IdAnimalNavigation")
                        .WithMany("Consulta")
                        .HasForeignKey("IdAnimal")
                        .HasConstraintName("FK_Consulta_IdAnimal");

                    b.HasOne("PetshopSENAICRUD.Models.StatusConsultum", "IdStatusNavigation")
                        .WithMany("Consulta")
                        .HasForeignKey("IdStatus")
                        .HasConstraintName("FK_Consulta_IdStatus");

                    b.HasOne("PetshopSENAICRUD.Models.Veterinario", "IdVeterinarioNavigation")
                        .WithMany("Consulta")
                        .HasForeignKey("IdVeterinario")
                        .HasConstraintName("FK_Consulta_IdVeterinario");

                    b.Navigation("IdAnimalNavigation");

                    b.Navigation("IdStatusNavigation");

                    b.Navigation("IdVeterinarioNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Feedback", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Feedback_IdCliente");

                    b.HasOne("PetshopSENAICRUD.Models.TipoFeedback", "IdTipoFeedbackNavigation")
                        .WithMany()
                        .HasForeignKey("IdTipoFeedback")
                        .HasConstraintName("FK_Feedback_IdTipoFeedback");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdTipoFeedbackNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Notificacao", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Notificacaos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Notificacao_IdCliente");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Pagamento", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.FormaDePagamento", "IdFormaDePagamentoNavigation")
                        .WithMany("Pagamentos")
                        .HasForeignKey("IdFormaDePagamento")
                        .HasConstraintName("FK_Pagamento_IdFormaDePagamento");

                    b.Navigation("IdFormaDePagamentoNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Receitum", b =>
                {
                    b.HasOne("PetshopSENAICRUD.Models.Consultum", "IdConsultaNavigation")
                        .WithMany("Receita")
                        .HasForeignKey("IdConsulta")
                        .HasConstraintName("FK_Receita_IdConsulta");

                    b.Navigation("IdConsultaNavigation");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Animal", b =>
                {
                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Cliente", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Feedbacks");

                    b.Navigation("Notificacaos");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Consultum", b =>
                {
                    b.Navigation("Receita");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.FormaDePagamento", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.PreferenciaDeNotificacao", b =>
                {
                    b.Navigation("IdClientes");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.StatusConsultum", b =>
                {
                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("PetshopSENAICRUD.Models.Veterinario", b =>
                {
                    b.Navigation("Consulta");
                });
#pragma warning restore 612, 618
        }
    }
}
