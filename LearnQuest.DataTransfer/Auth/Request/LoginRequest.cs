using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.DataTransfer.Auth.Request
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}