namespace LearnQuest.Dominio.Grade.Servicos.Comandos
{
    public class GradeListarComando
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public DateTime DateAssigned { get; set; }

        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}