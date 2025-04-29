using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Consultum
    {
        public Consultum()
        {
            Receita = new HashSet<Receitum>();
        }

        [Key]
        public int IdConsulta { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public int? IdStatus { get; set; }
        public int? IdAnimal { get; set; }
        public int? IdVeterinario { get; set; }

        [ForeignKey("IdAnimal")]
        public virtual Animal? IdAnimalNavigation { get; set; }

        [ForeignKey("IdStatus")]
        public virtual StatusConsultum? IdStatusNavigation { get; set; }

        [ForeignKey("IdVeterinario")]
        public virtual Veterinario? IdVeterinarioNavigation { get; set; }

        public virtual ICollection<Receitum> Receita { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}
