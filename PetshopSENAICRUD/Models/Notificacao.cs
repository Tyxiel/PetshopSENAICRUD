using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Notificacao
    {
        [Key]
        public int IdNotificacao { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = null!;

        [Required]
        public DateTime DataEnvio { get; set; }

        public int? IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}