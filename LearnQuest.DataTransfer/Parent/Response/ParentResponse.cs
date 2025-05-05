using LearnQuest.DataTransfer.Students.Response;

namespace LearnQuest.DataTransfer.Parent.Response
{
    public class ParentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<StudentsResponse> Children { get; set; } = new List<StudentsResponse>();

    }
}