using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetshopSENAICRUD.Models
{
    public partial class PetshopSENAIDBContext : DbContext
    {
        public PetshopSENAIDBContext()
        {
        }

        public PetshopSENAIDBContext(DbContextOptions<PetshopSENAIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Consultum> Consulta { get; set; } = null!;
        public virtual DbSet<CopiaDeSeguranca> CopiaDeSegurancas { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<FormaDePagamento> FormaDePagamentos { get; set; } = null!;
        public virtual DbSet<Notificacao> Notificacaos { get; set; } = null!;
        public virtual DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public virtual DbSet<PreferenciaDeNotificacao> PreferenciaDeNotificacaos { get; set; } = null!;
        public virtual DbSet<Receitum> Receita { get; set; } = null!;
        public virtual DbSet<StatusConsultum> StatusConsulta { get; set; } = null!;
        public virtual DbSet<Veterinario> Veterinarios { get; set; } = null!;
        public virtual DbSet<TipoFeedback> TipoFeedbacks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal).HasName("PK_Animal");
                entity.ToTable("Animal");

                entity.Property(e => e.Especie).HasMaxLength(150).HasColumnName("especie");
                entity.Property(e => e.Idade).HasColumnName("idade");
                entity.Property(e => e.Nome).HasMaxLength(50).HasColumnName("nome");
                entity.Property(e => e.Raca).HasMaxLength(150).HasColumnName("raca");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Animal_IdCliente");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente).HasName("PK_Cliente");
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Telefone).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
                entity.Property(e => e.Endereco).HasMaxLength(150).HasColumnName("endereco");
                entity.Property(e => e.Nome).HasMaxLength(150).HasColumnName("nome");
                entity.Property(e => e.Telefone).HasMaxLength(14).HasColumnName("telefone");

                entity.HasOne(d => d.IdPreferenciaNavigation) // This navigation property should be created in the Cliente model
            .WithMany() // Since PreferenciaDeNotificacao doesn't have a collection of Cliente, we use WithMany()
            .HasForeignKey(d => d.IdPreferencia)
            .HasConstraintName("FK_Cliente_PreferenciaDeNotificacao"); // Ensures the FK constraint is applied
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta).HasName("PK_Consulta");
                entity.Property(e => e.Data).HasColumnType("date").HasColumnName("data");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdAnimal)
                    .HasConstraintName("FK_Consulta_IdAnimal");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Consulta_IdStatus");

                entity.HasOne(d => d.IdVeterinarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdVeterinario)
                    .HasConstraintName("FK_Consulta_IdVeterinario");
            });

            modelBuilder.Entity<CopiaDeSeguranca>(entity =>
            {
                entity.HasKey(e => e.IdBackup).HasName("PK_CopiaDeSeguranca");
                entity.ToTable("CopiaDeSeguranca");

                entity.Property(e => e.DataExecucao).HasColumnType("date");
                entity.Property(e => e.Observacoes).HasMaxLength(200);
                entity.Property(e => e.StatusIntegridade).HasMaxLength(50);
                entity.Property(e => e.TamanhoBackup).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TipoBackup).HasMaxLength(50);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedback).HasName("PK_Feedback");
                entity.ToTable("Feedback");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Feedback_IdCliente");

                entity.HasOne(d => d.IdTipoFeedbackNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTipoFeedback)
                    .HasConstraintName("FK_Feedback_IdTipoFeedback");
            });

            modelBuilder.Entity<TipoFeedback>(entity =>
            {
                entity.HasKey(e => e.IdTipoFeedback).HasName("PK_TipoFeedback");
                entity.ToTable("TipoFeedback");

                entity.Property(e => e.Descricao).HasMaxLength(50).HasColumnName("descricao");
            });

            modelBuilder.Entity<FormaDePagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaDePagamento).HasName("PK_FormaDePagamento");
                entity.ToTable("FormaDePagamento");

                entity.Property(e => e.Descricao).HasMaxLength(50);
            });

            modelBuilder.Entity<Notificacao>(entity =>
            {
                entity.HasKey(e => e.IdNotificacao).HasName("PK_Notificacao");
                entity.ToTable("Notificacao");

                entity.Property(e => e.DataEnvio).HasColumnType("date").HasColumnName("data_envio");
                entity.Property(e => e.Tipo).HasMaxLength(50).HasColumnName("tipo");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Notificacaos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Notificacao_IdCliente");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento).HasName("PK_Pagamento");
                entity.ToTable("Pagamento");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)").HasColumnName("valor");

                entity.HasOne(d => d.IdFormaDePagamentoNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.IdFormaDePagamento)
                    .HasConstraintName("FK_Pagamento_IdFormaDePagamento");

                entity.HasOne(d => d.IdConsultaNavigation)
                   .WithMany(p => p.Pagamentos)
                   .HasForeignKey(d => d.IdConsulta)
                   .HasConstraintName("FK_Pagamento_IdConsulta");
            });

            modelBuilder.Entity<PreferenciaDeNotificacao>(entity =>
            {
                entity.HasKey(e => e.IdPreferencia).HasName("PK_PreferenciaDeNotificacao");
                entity.ToTable("PreferenciaDeNotificacao");

                entity.Property(e => e.Descricao).HasMaxLength(50).HasColumnName("descricao");
            });

            modelBuilder.Entity<Receitum>(entity =>
            {
                entity.HasKey(e => e.IdReceita).HasName("PK_Receita");
                entity.Property(e => e.Descricao).HasMaxLength(500).HasColumnName("descricao");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Receita)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("FK_Receita_IdConsulta");
            });

            modelBuilder.Entity<StatusConsultum>(entity =>
            {
                entity.HasKey(e => e.IdStatus).HasName("PK_StatusConsulta");
                entity.Property(e => e.Descricao).HasMaxLength(50).HasColumnName("descricao");
            });

            modelBuilder.Entity<Veterinario>(entity =>
            {
                entity.HasKey(e => e.IdVeterinario).HasName("PK_Veterinario");
                entity.ToTable("Veterinario");

                entity.Property(e => e.Crmv).HasMaxLength(9).HasColumnName("CRMV");
                entity.Property(e => e.Nome).HasMaxLength(150).HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
