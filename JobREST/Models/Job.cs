namespace JobREST.Models
{
    public class Job
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Job Id: {Id}, Job name: {Name}, Role: {Role}, Job Level: {Level}";
        }
    }
}
