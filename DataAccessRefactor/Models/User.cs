namespace DataAccessRefactor.Models
{
    public class User
    {
        public string Name { get; }
        public string Location { get; }
        public string Job { get; }
        public string Project { get; }

        public User(string name, string location, string job, string project)
        {
            Name = name;
            Location = location;
            Job = job;
            Project = project;
        }
    }
}