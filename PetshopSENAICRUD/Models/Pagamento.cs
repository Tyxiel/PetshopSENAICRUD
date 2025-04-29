using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }

        [Required]
        [Range(0, double.MaxValue)]  // Definindo que o valor não pode ser negativo
        public decimal Valor { get; set; }

        public int? IdFormaDePagamento { get; set; }

        [ForeignKey("IdFormaDePagamento")]
        public virtual FormaDePagamento? IdFormaDePagamentoNavigation { get; set; }

        public int? IdConsulta { get; set; }

        [ForeignKey("IdConsulta")]
        public virtual Consultum? IdConsultaNavigation { get; set; }
    }
}