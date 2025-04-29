using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class StatusConsultum
    {
        public StatusConsultum()
        {
            Consulta = new HashSet<Consultum>();
        }

        [Key]
        public int IdStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}