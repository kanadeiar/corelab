namespace ConsoleApp1
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Worker(int id, string name, DateTime birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
        }
        public Worker()
        {

        }
    }
}
