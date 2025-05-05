using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.DataTransfer.Teachers.Response;

namespace LearnQuest.DataTransfer.Auth.Response
{
    public class LoginResponse
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string TipoUsuario { get; set; }
    public List<TeacherClassesResponse> Turmas { get; set; } = new();
    public int? ParentId { get; set; } 
    public int? ClassId { get; set; } 

    }
}