namespace LearnQuest.Dominio.Parent.Servicos.Comandos
{
    public class ParentsInserirComando
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ParentsInserirComando(string name, string email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}