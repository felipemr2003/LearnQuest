using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.Dominio.Auth.Comandos
{
    public class RegisterComando
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string TipoUsuario { get; set; }

        public int? ParentId { get; set; }
        public int? ClassId { get; set; }
    }
}