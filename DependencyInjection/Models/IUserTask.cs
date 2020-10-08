namespace DependencyInjection.Models
{
    public interface IUserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}