using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class FormaDePagamento
    {
        public FormaDePagamento()
        {
            Pagamentos = new HashSet<Pagamento>();
        }

        [Key]  // Chave primária
        public int IdFormaDePagamento { get; set; }

        [Required]  // Torna o campo obrigatório
        [StringLength(50)]  // Limita o tamanho da string
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}
