namespace LearnQuest.Dominio.Student.Servicos.Comandos
{
    public class StudentsInserirComando
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int ParentId { get; set; }
        public int ClassId { get; set; }

        public StudentsInserirComando(string name, string email, string passwordHash, int parentId, int classId)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            ParentId = parentId;
            ClassId = classId;
        }
    }
}