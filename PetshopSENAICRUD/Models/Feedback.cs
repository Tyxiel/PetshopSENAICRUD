using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }

        [Required]
        public byte Tipo { get; set; }

        public int? IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? IdClienteNavigation { get; set; }


        public int? IdTipoFeedback { get; set; }

        [ForeignKey("IdTipoFeedback")]
        public virtual TipoFeedback? IdTipoFeedbackNavigation { get; set; }
    }
}
