using System.ComponentModel.DataAnnotations;

namespace PetshopSENAICRUD.Models
{
    public partial class TipoFeedback
    {
        [Key]
        public int IdTipoFeedback { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}
