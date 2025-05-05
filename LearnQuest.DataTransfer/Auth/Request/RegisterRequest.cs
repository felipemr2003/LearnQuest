using System.ComponentModel.DataAnnotations;

namespace LearnQuest.DataTransfer.Auth.Request
{
    public class RegisterRequest
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