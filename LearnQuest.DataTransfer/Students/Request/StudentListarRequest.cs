using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.DataTransfer.Students.Request
{
    public class StudentListarRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }
        public int ParentId { get; set; }

        public int ClassId { get; set; }

    }
}