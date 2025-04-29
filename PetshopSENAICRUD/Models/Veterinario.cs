using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Veterinario
    {
        public Veterinario()
        {
            Consulta = new HashSet<Consultum>();
        }

        [Key]
        public int IdVeterinario { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(9)]  // Limita o tamanho do CRMV
        public string Crmv { get; set; } = null!;

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}