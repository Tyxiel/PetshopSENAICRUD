using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class PreferenciaDeNotificacao
    {
        public PreferenciaDeNotificacao()
        {
            IdClientes = new HashSet<Cliente>();
        }

        [Key]
        public int IdPreferencia { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Cliente> IdClientes { get; set; }
    }
}