using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetshopSENAICRUD.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Consulta = new HashSet<Consultum>();
        }

        [Key]
        public int IdAnimal { get; set; }

        [Required]
        [StringLength(50)]  // Limita o tamanho da string
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]  // Limita o tamanho da string
        public string Especie { get; set; } = null!;

        [Required]
        [StringLength(150)]  // Limita o tamanho da string
        public string Raca { get; set; } = null!;

        [Required]
        [Range(0, 255)]  // Idade entre 0 e 255 anos
        public byte Idade { get; set; }

        public int? IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? IdClienteNavigation { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
