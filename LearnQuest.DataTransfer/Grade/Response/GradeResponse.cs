using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.DataTransfer.Grade.Response
{
    public class GradeResponse
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public DateTime DateAssigned { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}