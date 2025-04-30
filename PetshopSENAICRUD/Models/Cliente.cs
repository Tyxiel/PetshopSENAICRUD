using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetshopSENAICRUD.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Animals = new HashSet<Animal>();
            Feedbacks = new HashSet<Feedback>();
            Notificacaos = new HashSet<Notificacao>();
        }

        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Endereco { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(14)]
        public string Telefone { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notificacao> Notificacaos { get; set; }

        public int? IdPreferencia { get; set; }
        public virtual PreferenciaDeNotificacao? IdPreferenciaNavigation { get; set; }
    }
}
