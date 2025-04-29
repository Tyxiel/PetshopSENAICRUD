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
        [StringLength(150)]  // Limita o tamanho da string
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(150)]  // Limita o tamanho da string
        public string Endereco { get; set; } = null!;

        [Required]
        [EmailAddress]  // Valida o formato do e-mail
        [StringLength(100)]  // Limita o tamanho do e-mail
        public string Email { get; set; } = null!;

        [Required]
        [Phone]  // Valida o formato do telefone
        [StringLength(14)]  // Limita o tamanho do telefone
        public string Telefone { get; set; } = null!;

        // Navigation properties
        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notificacao> Notificacaos { get; set; }

        // Foreign key reference to PreferenciaDeNotificacao
        public int? IdPreferencia { get; set; }  // Nullable foreign key
        public virtual PreferenciaDeNotificacao? IdPreferenciaNavigation { get; set; }  // Navigation property to PreferenciaDeNotificacao
    }
}
