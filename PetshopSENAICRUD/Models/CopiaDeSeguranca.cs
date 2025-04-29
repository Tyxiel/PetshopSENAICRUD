using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class CopiaDeSeguranca
    {
        [Key]
        public int IdBackup { get; set; }

        [Required]
        public DateTime DataExecucao { get; set; }

        [Required]
        public TimeSpan HoraExecucao { get; set; }

        [Required]
        [Range(0, double.MaxValue)]  // Garantir que o tamanho do backup não seja negativo
        public decimal TamanhoBackup { get; set; }

        [Required]
        [StringLength(50)]  // Limita o tamanho da string
        public string TipoBackup { get; set; } = null!;

        [Required]
        [StringLength(50)]  // Limita o tamanho da string
        public string StatusIntegridade { get; set; } = null!;

        [StringLength(200)]  // Limita o tamanho da string de observações
        public string? Observacoes { get; set; }
    }
}
