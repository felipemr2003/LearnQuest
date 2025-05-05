using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.Dominio.Grade.Servicos.Comandos
{
    public class GradesInserirComando
    {
        public decimal Score { get; set; }
        public DateTime DateAssigned { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}