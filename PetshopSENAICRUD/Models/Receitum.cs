using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Receitum
    {
        [Key]
        public int IdReceita { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; } = null!;

        public int? IdConsulta { get; set; }

        [ForeignKey("IdConsulta")]
        public virtual Consultum? IdConsultaNavigation { get; set; }
    }
}