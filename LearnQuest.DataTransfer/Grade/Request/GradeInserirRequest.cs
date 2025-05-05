using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.DataTransfer.Grade.Request
{
    public class GradeInserirRequest
    {
        public decimal Score { get; set; }
        public DateTime DateAssigned { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}