namespace WebApi.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeveloperId { get; set; }

        public Developer Developer { get; set; }
    }
}
