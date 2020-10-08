namespace DependencyInjection.Models
{
    public class UserTask : IUserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}