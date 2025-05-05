using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.DataTransfer.Students.Response
{
    public class StudentsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}